using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer.PageObjects
{
    public class TreeTitle : PairedTag
    {
        public TreeTitle(int caseId) : base("div")
        {
            AddAttribute(new TagAttribute("class", "treeTitle"));
            AddSubTag(new StringValue($"Test Case {caseId} changes"));

        }
    }
}
