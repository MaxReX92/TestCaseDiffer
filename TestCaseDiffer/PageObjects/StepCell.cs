using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer.PageObjects
{
    public class StepCell : TableCell
    {
        public StepCell(int stepId) : base("stepIdCell")
        {
            AddAttribute(new TagAttribute("rowspan", "2"));
            AddSubTag(new StringValue($"Step {stepId}"));
        }
    }
}
