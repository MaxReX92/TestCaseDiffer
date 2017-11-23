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

		public IEnumerable<CaseChange> GetChanges(int testCaseId)
		{
			var workItem = _tfsClient.GetTestCase(testCaseId);
			if (workItem == null)
				throw new WorkItemNotFoundException();

			foreach (Revision revision in workItem.Revisions)
				yield return CaseChange.ParseRevision(revision);
		}
	}
}
