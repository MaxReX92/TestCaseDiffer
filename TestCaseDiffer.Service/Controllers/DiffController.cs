using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TestCaseDiffer.Service.Controllers
{	
	public class DiffController : ApiController
	{
		[Route("testcasediff/{testCaseId}")]
		[HttpGet]		
		public IHttpActionResult GetTestCaseDiff(int testCaseId)
		{
			return Ok(testCaseId);
		}
	}
}
