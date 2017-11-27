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
            var firstChange = new CaseChange { ChangeNum = 1, ChangeDate = DateTime.Now, ChangedBy = "Maxim Kuznetsov", Steps = "before" };
            var secondChange = new CaseChange { ChangeNum = 2, ChangeDate = DateTime.Now, ChangedBy = "Eugene Kuznetsov", Steps = "after" };

            var page = HtmlDiffPage.Create(12345, new[] { firstChange, secondChange });

            var html = page.Build();
        }
    }
}
