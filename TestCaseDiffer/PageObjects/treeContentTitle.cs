using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer.PageObjects
{
    public class TreeContentTitle : PairedTag
    {
        public TreeContentTitle(CaseChange currentChange) : base("div")
        {
            AddAttribute(new TagAttribute("class", "treeContentTitle"));
            ToggleId = $"toggleDiff{currentChange.ChangeNum}";
            AddAttribute(new TagAttribute("onclick", $"javascript:toggle('{ToggleId}');"));
            AddSubTag(new StringValue($"{currentChange.ChangeNum} changed {currentChange.ChangeDate} by {currentChange.ChangedBy}"));
        }

        public string ToggleId { get; }
    }
}
