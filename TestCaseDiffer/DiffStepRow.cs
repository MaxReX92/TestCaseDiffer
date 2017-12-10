using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var prevStepDiff = DiffStep.Create(prevStep);
            var currentStepDiff = DiffStep.Create(currentStep);

            var stepIdColumn = new PairedTag("th");
            stepIdColumn.AddSubTag(new StringValue($"Step {stepId}"));

            result.AddSubTag(stepIdColumn);
            result.AddSubTag(prevStepDiff);
            result.AddSubTag(currentStepDiff);
            return result;
        }
    }
}
