using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;
using TestCaseDiffer.PageObjects;

namespace TestCaseDiffer.PageObjects
{
    public class ChangesTree : PairedTag
    {
        public ChangesTree(int caseId, IEnumerable<CaseChange> changes) : base("div")
        {
            AddAttribute(new TagAttribute("class", "tree"));            
            AddSubTag(new TreeTitle(caseId));

            var content = new TreeContent();
            for (int i = changes.Count() - 1; i >= 0; i--)
            {
                var current = changes.ElementAt(i);
                var prev = i == 0 ? null : changes.ElementAt(i - 1);
                content.AddContent(prev, current);
            }

            AddSubTag(content);            
        }
    }
}
