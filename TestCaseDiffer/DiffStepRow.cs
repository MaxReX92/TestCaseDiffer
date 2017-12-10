using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.Differ;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer
{
    public class DiffStepRow : PairedTag
    {
        private DiffStepRow() : base("tr")
        {
        }

        public static DiffStepRow Create(int stepId, string prevStep, string currentStep)
        {
            var result = new DiffStepRow();

            //TODO: тут дифф шагов и форматирование

            var differ = new diff_match_patch();
            var diffs = differ.diff_main(prevStep, currentStep);

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
            
            var stepIdColumn = new PairedTag("th");
            stepIdColumn.AddSubTag(new StringValue($"Step {stepId}"));

            result.AddSubTag(stepIdColumn);
            result.AddSubTag(prevStepDiff);
            result.AddSubTag(currentStepDiff);
            return result;
        }
    }
}
