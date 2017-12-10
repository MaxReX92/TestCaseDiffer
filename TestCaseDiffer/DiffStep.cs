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
        public DiffStep() : base("th")
        {
            SubTag = new PairedTag("div");
            SubTag.AddAttribute(new TagAttribute("class", "changeDiff"));
            AddSubTag(SubTag);
        }

        private PairedTag SubTag { get; }
        
        public void AddEqualText(string equalText)
        {
            SubTag.AddSubTag(new StringValue(equalText));
        }

        public void AddDeletedText(string deletedText)
        {
            SubTag.AddSubTag(GetColoredText(deletedText, "red"));
        }

        public void AddInsertedText(string insertedText)
        {
            SubTag.AddSubTag(GetColoredText(insertedText, "green"));
        }

        private PairedTag GetColoredText(string text, string colorName)
        {
            var fontTag = new PairedTag("font");
            fontTag.AddAttribute(new TagAttribute("color", colorName));
            fontTag.AddSubTag(new StringValue(text));
            return fontTag;
        }
    }
}
