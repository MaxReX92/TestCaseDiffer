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
        public IEnumerable<CaseChange> GetChanges(int testCaseId)
        {
            var lines = File.ReadAllLines("StepsReturn.txt");
            var stepNum = 1;
            var changeHour = lines.Count();

            foreach (var line in lines)            
                yield return new CaseChange(stepNum++, "Kuznetsov Maxim", DateTime.Now.AddHours(-changeHour--), line);
        }
    }
}
