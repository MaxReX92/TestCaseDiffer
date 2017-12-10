using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.Exceptions;
using TfsApi.WorkItemTracking;

namespace TestCaseDiffer.Tfs
{
	public class TfsApiClient : ITfsClient
	{
		private readonly WorkItemStore _workItemStore;

		public TfsApiClient(ITfsSettings settings)
		{
			_workItemStore = WorkItemStoreFactory.GetWorkItemStore(new Uri(settings.TfsConnection));            
		}

		public WorkItem GetTestCase(int testCaseId)
		{
			var workItem = _workItemStore.GetWorkItem(testCaseId);
            if (workItem.Type.Name != "TestCase")
                throw new WorkItemTypeException();
            return workItem;
		}		
	}
}
