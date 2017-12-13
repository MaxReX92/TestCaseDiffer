using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer.PageObjects
{
    public class TreeContent : PairedTag
    {
        public TreeContent() : base("div")
        {
            AddAttribute(new TagAttribute("class", "treeContent"));
        }

        public void AddContent(CaseChange prev, CaseChange current)
        {
            var prevSteps = prev == null ? String.Empty : prev.Steps;
            var content = new TreeContentTitle(current);
            AddSubTag(content);

            var table = new ChangeTable(content.ToggleId, prevSteps, current.Steps);
            AddSubTag(table);
        }
    }
}
