using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer.PageObjects
{
	public class MainPage : PairedTag
	{
		public MainPage(int testCase, IEnumerable<CaseChange> changes) : base("html")
		{
			AddSubTag(Head = new PairedTag("head"));
            var body = new PairedTag("body");
            body.AddAttribute(new TagAttribute("class", "mainPage"));
			AddSubTag(Body = body);

            var meta = new SingleTag("meta");
            meta.AddAttribute(new TagAttribute("charset", "utf-8"));
            Head.AddSubTag(meta);

            var style = new PairedTag("style");
            style.AddSubTag(new StringValue(Constants.Style));
            Head.AddSubTag(style);

            var script = new PairedTag("script");
            script.AddAttribute(new TagAttribute("language", "javascript"));
            script.AddSubTag(new StringValue(Constants.JavaScript));
            Head.AddSubTag(script);
            Body.AddSubTag(new ChangesTree(testCase, changes.OrderBy(x => x.ChangeNum)));
        }

		public PairedTag Head { get; }
		public PairedTag Body { get; }

        public override string Build()
        {
			return String.Concat("<!doctype html>\n", base.Build());
		}        
    }
}
