using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestCaseDiffer.PageObjects;
using TestCaseDiffer.Tfs;

namespace TestCaseDiffer
{
	public class HtmlDiffCreator : IDiffPageCreator
	{
		private readonly IChangesProvider _changesProvider;

		public HtmlDiffCreator(IChangesProvider changesProvider)
		{
			_changesProvider = changesProvider;
		}

		public string CreateDiffPage(int testCaseId)
		{
			var changes = _changesProvider.GetChanges(testCaseId);
            var page = new MainPage(testCaseId, changes);
            return page.Build();  			
        }
	}
}
