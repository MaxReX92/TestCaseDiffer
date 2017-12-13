using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer.PageObjects
{
    public class BackgroundColoredText : PairedTag
    {
        public BackgroundColoredText(string className, string text) : base("span")
        {
            AddAttribute(new TagAttribute("class", className));
            AddSubTag(new StringValue(text));
        }
    }
}
