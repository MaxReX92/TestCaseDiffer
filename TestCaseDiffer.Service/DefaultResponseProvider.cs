using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Service
{
	public class DefaultResponseProvider : IResponseProvider
	{
		public HttpResponseMessage SuccessStringResponse(string content)
		{
			return CreateStringResponse(content, HttpStatusCode.OK);
		}

		public HttpResponseMessage CreateStringResponse(string content, HttpStatusCode code)
		{
			var response = new HttpResponseMessage();
			response.Content = new StringContent(content);
			response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
			return response;
		}
	}
}
