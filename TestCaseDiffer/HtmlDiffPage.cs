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
		private HtmlDiffPage() : base("html")
		{
			AddSubTag(Head = new PairedTag("head"));
			AddSubTag(Body = new PairedTag("body"));
		}

		public PairedTag Head { get; }
		public PairedTag Body { get; }

        public override string Build()
        {
            return String.Concat("<!doctype html>\n", base.Build());
        }

        public static HtmlDiffPage Create(int testCase, IEnumerable<CaseChange> changes)
        {
            var page = new HtmlDiffPage();
            var meta = new SingleTag("meta");
            meta.AddAttribute(new TagAttribute("charset", "utf-8"));
            page.Head.AddSubTag(meta);

            var style = new PairedTag("style");
            style.AddSubTag(new StringValue(Constants.Style));
            page.Head.AddSubTag(style);

            var script = new PairedTag("script");
            script.AddAttribute(new TagAttribute("language", "javascript"));
            script.AddSubTag(new StringValue(Constants.JavaScript));
            page.Head.AddSubTag(script);
            page.Body.AddSubTag(ChangesTree.Create(testCase, changes.OrderBy(x => x.ChangeNum)));

            return page;
        }
    }
}
