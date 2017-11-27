using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer
{
    public class DiffStep : PairedTag
    {
        private DiffStep() : base("th")
        {
            SubTag = new PairedTag("div");
            SubTag.AddAttribute(new TagAttribute("class", "changeDiff"));
            AddSubTag(SubTag);
        }

        private PairedTag SubTag { get; }

        public static DiffStep Create(string steps)
        {
            var diffSteps = new DiffStep();
            diffSteps.SubTag.AddSubTag(new StringValue(steps));

            return diffSteps;
        }
    }
}
