using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Tfs
{
	public interface IChangesProvider
	{
		IEnumerable<CaseChange> GetChanges(int testCaseId);
	}
}
