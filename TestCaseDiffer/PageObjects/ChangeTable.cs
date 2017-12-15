using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using TestCaseDiffer.Differ;
using TestCaseDiffer.Exceptions;
using TestCaseDiffer.HtmlTags;
using TestCaseDiffer.PageObjects;

namespace TestCaseDiffer.PageObjects
{
    public class ChangeTable : PairedTag
    {
        public ChangeTable(string id, string prevSteps, string currentSteps) : base("table")
        {            
            AddAttribute(new TagAttribute("class", "changesTable"));
            AddAttribute(new TagAttribute("id", id));

            Fill(prevSteps, currentSteps);
        }
        
        public void Fill(string prevSteps, string currentSteps)
        {
			var notEmptySteps = currentSteps;
			if (String.IsNullOrWhiteSpace(notEmptySteps))
				notEmptySteps = prevSteps;

			if (String.IsNullOrWhiteSpace(notEmptySteps))
				return;
			
			var xml = XDocument.Parse(notEmptySteps);
            var stepsNode = xml.Element("steps");

			var prevStepsDoc = String.IsNullOrWhiteSpace(prevSteps) ? null : XDocument.Parse(prevSteps);
			var currentStepsDoc = String.IsNullOrWhiteSpace(currentSteps) ? null : XDocument.Parse(currentSteps);

			foreach (var step in stepsNode.Elements())
            {
                if (step.Name != "step")
                    continue;

                var stepIdAttr = step.Attribute("id");
                if (!Int32.TryParse(stepIdAttr.Value, out int stepId))
                    throw new WrongStepsException("Step id missed");

				var prevStep = GetStepById(prevStepsDoc, stepId);
				var currentStep = GetStepById(currentStepsDoc, stepId);

				var prevStrs = prevStep == null ? Enumerable.Empty<XElement>() : prevStep.XPathSelectElements("parameterizedString");
				var currentStrs = prevStep == null ? Enumerable.Empty<XElement>() : currentStep.XPathSelectElements("parameterizedString");

				var resultRow = CreateRow(1, prevStrs, currentStrs);
				var actionRow = CreateRow(0, prevStrs, currentStrs);
				actionRow.InsertSubTag(0, new StepCell(stepId));

				AddSubTag(actionRow);
				AddSubTag(resultRow);				
            }
        }

		private static TableRow CreateRow(int index, IEnumerable<XElement> prevStrs, IEnumerable<XElement> currentStrs)
		{
			var prev = GetElementAtValue(index, prevStrs);
			var current = GetElementAtValue(index, currentStrs);

			return new TableRow(prev, current);
        }

		private static XElement GetStepById(XDocument steps, int stepId)
        {
            if (steps == null)
                return null;
			
            return steps.XPathSelectElement($"steps/step[@id='{stepId}']");            
        }

		private static string GetElementAtValue(int index, IEnumerable<XElement> elements)
		{
			var element = elements.ElementAtOrDefault(index);
			return element == null ? String.Empty : element.Value;
		}        
	}
}
