using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer
{
	public class HtmlDiffPage : PairedTag
	{
		public HtmlDiffPage() : base("html")
		{
			AddSubTag(Head = new PairedTag("head"));
			AddSubTag(Body = new PairedTag("body"));
		}

		public PairedTag Head { get; }
		public PairedTag Body { get; }
	}
}
