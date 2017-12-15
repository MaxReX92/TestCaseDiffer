using NLog;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TestCaseDiffer.Exceptions;

namespace TestCaseDiffer.Service.Controllers
{
	public class DiffController : ApiController
	{
		private readonly ILogger _logger;
		private readonly IResponseProvider _responseProvider;
		private readonly IDiffPageCreator _pageCreator;

		public DiffController(IDiffPageCreator pageCreator, IResponseProvider responseProvider)
		{
			_logger = LogManager.GetCurrentClassLogger();
			_pageCreator = pageCreator;
			_responseProvider = responseProvider;
		}

		[Route("testcasediff/{testCaseId}")]
		[HttpGet]
		public HttpResponseMessage GetTestCaseDiff(string testCaseId)
		{
			_logger.Info($"Create test case {testCaseId} diff request");
			if (!Int32.TryParse(testCaseId, out int parsedId))
			{
				_logger.Error($"Fail to parse id {testCaseId}");
				return _responseProvider.CreateStringResponse($"Fail to parse id {testCaseId}", HttpStatusCode.BadRequest);
			}

			try
			{
				var page = _pageCreator.CreateDiffPage(parsedId);
				return _responseProvider.SuccessStringResponse(page);
			}
            catch (WorkItemTypeException)
			{
				_logger.Error($"Work item {testCaseId} is not a test case.");
				return _responseProvider.CreateStringResponse($"Work item {testCaseId} is not a test case. Only test case work items are supported.", HttpStatusCode.BadRequest);
			}
			catch (WorkItemNotFoundException)
			{
				_logger.Error($"Work item {testCaseId} not found.");
				return _responseProvider.CreateStringResponse($"Work item {testCaseId} not found.", HttpStatusCode.BadRequest);
			}
			catch (WrongStepsException ex)
			{
				_logger.Error(ex, $"Fail to parse test case steps.");
				return _responseProvider.CreateStringResponse($"Fail to parse test case steps.", HttpStatusCode.InternalServerError);
			}
			catch (Exception ex)
			{
				_logger.Error(ex, "Fail to create diff");
				return _responseProvider.CreateStringResponse($"Fail to create diff: {ex.Message}", HttpStatusCode.InternalServerError);
			}
		}
	}
}

