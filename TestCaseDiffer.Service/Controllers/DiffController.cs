using NLog;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TestCaseDiffer.Service.Controllers
{	
	public class DiffController : ApiController
	{
		private readonly ILogger _logger;
		private readonly IResponseProvider _responseProvider;

		public DiffController(IResponseProvider responseProvider)
		{
			_logger = LogManager.GetCurrentClassLogger();
			_responseProvider = responseProvider;
		}

		[Route("testcasediff/{testCaseId}")]
		[HttpGet]
		public HttpResponseMessage GetTestCaseDiff(long testCaseId)
		{
			var page = $"<html><body>Hello World<br>{testCaseId}</body></html>";
			return _responseProvider.Success(page);
		}
	}
}

