using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;
using TestCaseDiffer.Differ;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer.PageObjects
{
    public class TableRow : PairedTag
    {
        public TableRow(string prev, string current) : base("tr")
        {
            AddAttribute(new TagAttribute("class", "tableRow"));

			var prevDecoded = ReplaceHtml(prev);
			var currentDecoded = ReplaceHtml(current);
			var differ = new diff_match_patch();
            var diffs = differ.diff_main(prevDecoded, currentDecoded, false);

            var prevStepDiff = new DiffCell();
            var currentStepDiff = new DiffCell();

            foreach (var diff in diffs)
            {
                diff.ToString();
                switch (diff.operation)
                {
                    case Operation.DELETE:
                        prevStepDiff.AddDeletedText(diff.text);
                        break;
                    case Operation.INSERT:
                        currentStepDiff.AddInsertedText(diff.text);
                        break;
                    case Operation.EQUAL:
                        prevStepDiff.AddEqualText(diff.text);
                        currentStepDiff.AddEqualText(diff.text);
                        break;
                    default:
                        break;
                }
            }
			
            AddSubTag(prevStepDiff);
            AddSubTag(currentStepDiff);
        }

		private string ReplaceHtml(string str)
		{			
			//Сначала декодим, потом заменяем <BR> на \n, потом удаляем всё остальное
			return Regex.Replace(Regex.Replace(HttpUtility.HtmlDecode(str), "<(br|BR).?>", "\n"), "<.*?>", String.Empty);			
		}
    }
}
