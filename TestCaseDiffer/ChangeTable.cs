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
			var notEmptySteps = currentSteps;
			if (String.IsNullOrWhiteSpace(notEmptySteps))
				notEmptySteps = prevSteps;

			if (String.IsNullOrWhiteSpace(notEmptySteps))
				return table;
			
			var xml = XDocument.Parse(notEmptySteps);
            var stepsNode = xml.Element("steps");            
            foreach (var step in stepsNode.Elements())
            {
                if (step.Name != "step")
                    continue;

                var stepIdAttr = step.Attribute("id");
                if (!Int32.TryParse(stepIdAttr.Value, out int stepId))
                    throw new WrongStepsException("Step id missed");

				var prevStep = GetStepById(prevSteps, stepId);
				var currentStep = GetStepById(currentSteps, stepId);

				var prevStrs = prevStep == null ? Enumerable.Empty<XElement>() : prevStep.XPathSelectElements("parameterizedString");
				var currentStrs = prevStep == null ? Enumerable.Empty<XElement>() : currentStep.XPathSelectElements("parameterizedString");

				var actionRow = CreateRow(0, prevStrs, currentStrs);
				var resultRow = CreateRow(1, prevStrs, currentStrs);

				var stepIdColumn = new PairedTag("td");
				stepIdColumn.AddAttribute(new TagAttribute("rowspan", "2"));
				stepIdColumn.AddAttribute(new TagAttribute("class", "stepIdColumn"));
				stepIdColumn.AddSubTag(new StringValue($"Step {stepId}"));
				actionRow.InsertSubTag(0, stepIdColumn);

				table.AddSubTag(actionRow);
				table.AddSubTag(resultRow);				
            }

            table.AddAttribute(new TagAttribute("id", id));
            return table;
        }

		private static PairedTag CreateRow(int index, IEnumerable<XElement> prevStrs, IEnumerable<XElement> currentStrs)
		{
			var result = new PairedTag("tr");			
			var prev = GetElementAtValue(index, prevStrs);
			var current = GetElementAtValue(index, currentStrs);

			AddChanges(prev, current, result);
			return result;
		}

		private static XElement GetStepById(string steps, int stepId)
        {
            if (String.IsNullOrEmpty(steps))
                return null;

            var prevXml = XDocument.Parse(steps);
            return prevXml.XPathSelectElement($"steps/step[@id='{stepId}']");            
        }

		private static string GetElementAtValue(int index, IEnumerable<XElement> elements)
		{
			var element = elements.ElementAtOrDefault(index);
			return element == null ? String.Empty : element.Value;
		}

		private static void AddChanges(string prev, string current, PairedTag row)
		{
			var differ = new diff_match_patch();
			var diffs = differ.diff_main(prev, current, false);

			var prevStepDiff = new DiffStep();
			var currentStepDiff = new DiffStep();

			foreach (var diff in diffs)
			{
				diff.ToString();
				switch (diff.operation)
				{
					case Operation.DELETE:
						prevStepDiff.AddDeletedText(diff.text);
						break;
					case Operation.INSERT:
						currentStepDiff.AddInsertedText(diff.text);
						break;
					case Operation.EQUAL:
						prevStepDiff.AddEqualText(diff.text);
						currentStepDiff.AddEqualText(diff.text);
						break;
					default:
						break;
				}
			}

			var subRow = new PairedTag("td");
			subRow.AddSubTag(prevStepDiff);
			subRow.AddSubTag(currentStepDiff);
			row.AddSubTag(subRow);
		}
	}
}
