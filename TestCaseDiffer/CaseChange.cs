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
        private CaseChange()
        {
        }

        public CaseChange(int changeNum, string changedBy, DateTime changeTime, string steps)
        {
            ChangeNum = changeNum;
            ChangedBy = changedBy;
            ChangeDate = changeTime;
            Steps = steps;
        }

        public int ChangeNum { get; private set; }

		public DateTime ChangeDate { get; private set; }

		public string ChangedBy { get; private set; }

		public string Steps { get; private set; }

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
