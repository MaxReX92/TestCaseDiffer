using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using TestCaseDiffer.Exceptions;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer
{
    public class ChangeTable : PairedTag
    {
        private ChangeTable() : base("table")
        {            
            AddAttribute(new TagAttribute("class", "changeTable"));
        }
        
        public static ChangeTable Create(string id, string prevSteps, string currentSteps)
        {
            var table = new ChangeTable();
            var currentXml = XDocument.Parse(currentSteps);

            var currentStepsNode = currentXml.Element("steps");            
            foreach (var currentStep in currentStepsNode.Elements())
            {
                if (currentStep.Name != "step")
                    continue;

                var stepIdAttr = currentStep.Attribute("id");
                if (!Int32.TryParse(stepIdAttr.Value, out int stepId))
                    throw new WrongStepsException("Step id missed");
                               
                table.AddSubTag(DiffStepRow.Create(stepId, GetSameStep(prevSteps, stepId), currentStep.Value));
            }

            table.AddAttribute(new TagAttribute("id", id));
            return table;
        }

        private static string GetSameStep(string steps, int stepId)
        {
            if (String.IsNullOrEmpty(steps))
                return String.Empty;

            var prevXml = XDocument.Parse(steps);
            var prevStep = prevXml.XPathSelectElement($"steps/step[@id='{stepId}']");
            return prevStep == null ? String.Empty : prevStep.Value;
        }
    }
}
