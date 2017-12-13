using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using TestCaseDiffer.Differ;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer
{
    public class DiffStepRow : PairedTag
    {
        public DiffStepRow() : base("tr")
        {
        }		
	}
}
