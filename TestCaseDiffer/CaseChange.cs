using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer
{
	public class CaseChange
	{
		public int ChangeNum { get; set; }

		public DateTime ChangeDate { get; set; }

		public string ChangedBy { get; set; }

		public string Steps { get; set; }

		public static CaseChange ParseRevision(Revision caseRevision)
		{
			var result = new CaseChange();
			if (TryGetField(caseRevision, "Rev", out int num))
				result.ChangeNum = num;

			if (TryGetField(caseRevision, "Changed by", out string changedBy))
				result.ChangedBy = changedBy;

			if (TryGetField(caseRevision, "Changed Date", out DateTime changeTime))
				result.ChangeDate = changeTime;

			if (TryGetField(caseRevision, "Steps", out string steps))
				result.Steps = steps;

			return result;
		}

		private static bool TryGetField<T>(Revision revision, string name, out T value)
		{
			value = default(T);
			if (!revision.Fields.Contains(name))
				return false;

			value = (T)revision.Fields[name].Value;
			return true;
		}
	}
}
