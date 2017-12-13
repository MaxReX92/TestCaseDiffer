using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer.PageObjects
{
    public class TableCell : PairedTag
    {
        public TableCell(string className) : base("td")
        {
            AddAttribute(new TagAttribute("class", className));
        }
    }
}
