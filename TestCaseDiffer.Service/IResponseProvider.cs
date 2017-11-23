using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Service
{
	public interface IResponseProvider
	{
		HttpResponseMessage SuccessStringResponse(string content);

		HttpResponseMessage CreateStringResponse(string content, HttpStatusCode code);
	}
}
