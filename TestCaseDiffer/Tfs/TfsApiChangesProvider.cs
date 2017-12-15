using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.Exceptions;

namespace TestCaseDiffer.Tfs
{
	public class TfsApiChangesProvider : IChangesProvider
	{
		private readonly ITfsClient _tfsClient;

		public TfsApiChangesProvider(ITfsClient tfsClient)
		{
			_tfsClient = tfsClient;
		}

		public ICollection<CaseChange> GetChanges(int testCaseId)
		{
			var workItem = _tfsClient.GetTestCase(testCaseId);
			if (workItem == null)
				throw new WorkItemNotFoundException();

			return workItem.Revisions.OfType<Revision>().Select(x => CaseChange.ParseRevision(x)).ToList();
		}
	}
}
