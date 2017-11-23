using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer
{
	public interface IDiffPageCreator
	{
		string CreateDiffPage(int testCaseId);
	}
}
