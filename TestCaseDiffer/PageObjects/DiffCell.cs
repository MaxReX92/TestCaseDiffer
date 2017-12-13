using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;
using TestCaseDiffer.PageObjects;

namespace TestCaseDiffer.PageObjects
{
    public class DiffCell : TableCell
    {                
        public DiffCell() : base("tableCell")
        {
        }

        public void AddEqualText(string equalText)
        {
            AddSubTag(new StringValue(equalText));
        }

        public void AddDeletedText(string deletedText)
        {
            AddSubTag(new BackgroundColoredText("deletedText", deletedText));
        }

        public void AddInsertedText(string insertedText)
        {
            AddSubTag(new BackgroundColoredText("addedText", insertedText));
        }
    }
}
