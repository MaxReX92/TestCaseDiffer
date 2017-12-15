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
            ToggleId = $"toggleDiff{currentChange.ChangeNum}";
			TitleId = $"title{currentChange.ChangeNum}";

            AddAttribute(new TagAttribute("class", "treeContentTitle"));
			AddAttribute(new TagAttribute("id", TitleId));
			AddAttribute(new TagAttribute("onclick", $"javascript:toggle('{ToggleId}','{TitleId}');"));
            AddSubTag(new StringValue($"{currentChange.ChangeNum} changed {currentChange.ChangeDate} by {currentChange.ChangedBy}"));
        }

        public string ToggleId { get; }
        private string TitleId { get; }
	}
}
