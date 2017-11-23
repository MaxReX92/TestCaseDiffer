using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Service
{
	public class DefaultResponseProvider : IResponseProvider
	{
		public HttpResponseMessage Success(string htmlPage)
		{
			var response = new HttpResponseMessage();
			response.Content = new StringContent(htmlPage);
			response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
			return response;
		}
	}
}
