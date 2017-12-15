using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.Tfs;

namespace TestCaseDiffer
{
    public class PreparedChangesProvider : IChangesProvider
    {
        public ICollection<CaseChange> GetChanges(int testCaseId)
        {
            var lines = File.ReadAllLines("StepsReturn.txt");
            var stepNum = 1;
            var changeHour = lines.Count();

			return lines.Select(x => new CaseChange(stepNum++, "Kuznetsov Maxim", DateTime.Now.AddHours(-changeHour--), x)).ToList();
        }
    }
}
