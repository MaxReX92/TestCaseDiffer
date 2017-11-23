using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.Service
{
	[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
	public class LoggingMiddleware : OwinMiddleware
	{
		private readonly ILogger _logger;

		public LoggingMiddleware(OwinMiddleware next, IAppBuilder app) : base(next)
		{
			_logger = app.CreateLogger<LoggingMiddleware>();
		}

		public override async Task Invoke(IOwinContext context)
		{
			try
			{
				Log(context.Request);
				if (Next != null)
					await Next.Invoke(context);
				Log(context.Response);
			}
			catch (Exception ex)
			{
				_logger.WriteError("Exception caught", ex);
			}
		}

		private void Log(IOwinResponse response)
		{
			_logger.WriteInformation($"Response code: {response.StatusCode} {response.ReasonPhrase}");
		}

		private void Log(IOwinRequest request)
		{
			_logger.WriteInformation(BuildMessage(request));
		}

		private static string BuildMessage(IOwinRequest request)
		{
			var buffer = new StringBuilder();
			buffer.Append(request.IsSecure ? "Secure" : "Insecure");

			string requestSource = Dns.GetHostEntry(request.RemoteIpAddress)?.HostName ?? request.RemoteIpAddress.ToString();
			buffer.Append($" {request.Method} {request.Uri} from {requestSource}:{request.RemotePort} with");

			var identity = request.User?.Identity;
			if (identity != null && identity.IsAuthenticated)
				buffer.Append($" {identity.AuthenticationType} by {identity.Name}");
			else
				buffer.Append("out auth");

			return buffer.ToString();
		}
	}
}
