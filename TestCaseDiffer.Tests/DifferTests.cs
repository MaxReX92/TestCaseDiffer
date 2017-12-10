using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.Differ;

namespace TestCaseDiffer.Tests
{
    [TestClass]
    public class DifferTests
    {
        [TestMethod]
        public void MainDiffTest()
        {
            var differ = new diff_match_patch();

            var diffs = differ.diff_main("a b c d e", "a b c d r");
        }
    }
}
