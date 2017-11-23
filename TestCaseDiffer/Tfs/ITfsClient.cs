using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Tfs
{
	public interface ITfsClient
	{
		WorkItem GetTestCase(int testCaseId);
	}
}
