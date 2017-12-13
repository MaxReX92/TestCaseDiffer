using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer
{
    public class ChangesTree : PairedTag
    {
        private ChangesTree(int caseId) : base("div")
        {
            AddAttribute(new TagAttribute("class", "tree"));

            var title = new PairedTag("div");
            title.Attributes.Add( new TagAttribute("class", "treeTitle"));
            title.AddSubTag(new StringValue($"Test Case {caseId} changes"));
            AddSubTag(title);

            Changes = new PairedTag("div");
            Changes.AddAttribute(new TagAttribute("class", "changes"));
            AddSubTag(Changes);
        }

        private PairedTag Changes { get; }

        public static ChangesTree Create(int caseId, IEnumerable<CaseChange> changes)
        {
            var tree = new ChangesTree(caseId);

            for (int i = changes.Count() - 1; i >= 0; i--)
            {
                var current = changes.ElementAt(i);
                var prev = i == 0 ? null : changes.ElementAt(i - 1);
                tree.AddCaseChange(prev, current);
            }

            return tree;
        }

        private void AddCaseChange(CaseChange prev, CaseChange current)
        {
            var prevSteps = prev == null ? String.Empty : prev.Steps;

            var toggleId = $"toggleDiff{current.ChangeNum}";
            var title = new PairedTag("div");
            title.AddAttribute(new TagAttribute("class", "changeTitle"));
            title.AddAttribute(new TagAttribute("onclick", $"javascript:toggle('{toggleId}');"));
            title.AddSubTag(new StringValue($"{current.ChangeNum} changed {current.ChangeDate} by {current.ChangedBy}"));
            Changes.AddSubTag(title);

            var table = ChangeTable.Create(toggleId, prevSteps, current.Steps);
            Changes.AddSubTag(table);
        }
    }
}
