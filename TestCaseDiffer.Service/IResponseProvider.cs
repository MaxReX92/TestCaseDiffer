using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Service
{
	public interface IResponseProvider
	{
		HttpResponseMessage Success(string htmlPage);
	}
}
