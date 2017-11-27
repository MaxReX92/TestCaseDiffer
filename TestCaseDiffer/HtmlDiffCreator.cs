using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.Tfs;

namespace TestCaseDiffer
{
	public class HtmlDiffCreator : IDiffPageCreator
	{
		private readonly IChangesProvider _changesProvider;

		public HtmlDiffCreator(IChangesProvider stepsProvider)
		{
			_changesProvider = stepsProvider;
		}

		public string CreateDiffPage(int testCaseId)
		{
			var changes = _changesProvider.GetChanges(testCaseId);
            var page = HtmlDiffPage.Create(testCaseId, changes);
            return page.Build();
            //return "<DIV><DIV><P>Перенастроить AMA на несуществующий инстанс KLDFS <BR/></P></DIV></DIV><DIV>Ошибка KLDFS - service unavailable<BR/><P>&nbsp;</P></DIV><DIV><P>&nbsp;</P><DIV>Отправить на обработку в AMA несуществующий в KLDFS файл<BR/></DIV><P>&nbsp;</P></DIV><DIV>Ошибка KLDFS - file unavailable<P>&nbsp;</P></DIV><DIV><DIV><P>&nbsp;Перенастроить AMA на несуществующий инстанс Sandbox</P></DIV></DIV><DIV><P>Ошибка Sandbox - service unavailable</P></DIV><DIV>Перенастроить AMA на инстанс Sandbox нагруженный задачами от AWP<DIV><P>&nbsp;</P></DIV></DIV><DIV>Часть запросов завершается с timeout <BR/><P>&nbsp;</P></DIV><DIV><P>Через веб интерфейс Sandbox (https://sandbox-beta.sbx.avp.ru/results) удалить результаты до того как их выкачает AMA <BR/></P></DIV><P>Ошибка Sandbox - results deleted<BR/></P>";
		}
	}
}
