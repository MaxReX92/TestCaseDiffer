using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.HtmlTags;

namespace TestCaseDiffer.Tests
{
    [TestClass]
    public class TagsBuildTests
    {
        [TestMethod]
        public void BuildTest()
        {
            var before = new PairedTag("div");
            before.SubTags.Add(new StringValue("Before"));
            before.Attributes.Add(new TagAttribute("class", "changeDiff"));

            var after = new PairedTag("div");
            after.SubTags.Add(new StringValue("After"));

            var beforeLine = new PairedTag("th");
            beforeLine.SubTags.Add(before);

            var afterLine = new PairedTag("th");
            afterLine.SubTags.Add(afterLine);

            var tr = new PairedTag("tr");
            tr.SubTags.Add(beforeLine);
            tr.SubTags.Add(afterLine);
            tr.Attributes.Add(new TagAttribute("class", "changeTable"));
            tr.Attributes.Add(new TagAttribute("id", "toggleText1"));

            var table = new PairedTag("table");
            //table.SubTags.

            var title = new PairedTag("div");
            title.SubTags.Add(new StringValue("First"));
            title.Attributes.Add(new TagAttribute("class", "changeTitle"));
            title.Attributes.Add(new TagAttribute("onclick", "javascript:toggle('toggleText2');"));
        }
    }
}
