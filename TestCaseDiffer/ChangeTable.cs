using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer
{
    public class ChangeTable : PairedTag
    {
        public ChangeTable(DiffStep prev, DiffStep current) : base("table")
        {
            var tr = new PairedTag("tr");
            tr.AddSubTag(prev);
            tr.AddSubTag(current);
            AddAttribute(new TagAttribute("class", "changeTable"));
            AddSubTag(tr);
        }

        public static ChangeTable Create(string id, string prevSteps, string currentSteps)
        {
            var prevDiff = DiffStep.Create(prevSteps);
            var currentDiff = DiffStep.Create(currentSteps);

            var table = new ChangeTable(prevDiff, currentDiff);
            table.AddAttribute(new TagAttribute("id", id));
            return table;
        }
    }
}
