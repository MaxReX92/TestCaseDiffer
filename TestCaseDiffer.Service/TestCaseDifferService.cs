using NLog;
using NLog.Owin.Logging;
using Owin;
using Swashbuckle.Application;
using Swashbuckle.Examples;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Tracing;
using TestCaseDiffer.Service.Properties;

namespace TestCaseDiffer.Service
{
	public class TestCaseDifferService
	{
		private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
		private IDisposable _webApp;
		private readonly IHttpControllerActivator _controlerActivator;
		private readonly AppStarter _appStart;

		public TestCaseDifferService(IHttpControllerActivator controlerActivator, AppStarter appStart)
		{
			_appStart = appStart;
			_controlerActivator = controlerActivator;
		}

		public void Start()
		{
			string url = null;
			try
			{
				url = Settings.Default.ListenUrl;
				_logger.Debug($"Start listen url {url}");
				_webApp = _appStart(url, appBuilder =>
				{
					appBuilder
						.UseNLog()
						.Use<LoggingMiddleware>(appBuilder)
						.UseWebApi(CreateHttpConfiguration(appBuilder));
					SetAuthentication(appBuilder);
				});
			}
			catch (Exception ex) when
			(
				ex.InnerException is HttpListenerException &&
				((HttpListenerException)ex.InnerException).ErrorCode == 5) // Access denied
			{
				if (!url.EndsWith("/"))
					url += '/';

				_logger.Fatal($"{nameof(TestCaseDifferService)}.{nameof(Start)} error: {ex.InnerException.Message} on creating listener." +
							$" To fix run 'netsh http add urlacl url={url} user={System.Security.Principal.WindowsIdentity.GetCurrent().Name}'");
				throw;
			}
			catch (Exception ex)
			{
				_logger.Fatal($"{nameof(TestCaseDifferService)}.{nameof(Start)} error: {ex.GetBaseException()}");
				throw;
			}
		}

		public void Stop()
		{
			try
			{
				// _webApp?.Dispose(); owinBug
				// http://stackoverflow.com/questions/22982278/disposing-microsoft-owin-hosting-webapp-throws-system-objectdisposedexception/37685252#comment73761069_37685252 
			}
			catch (Exception ex)
			{
				_logger.Fatal(ex.GetBaseException().ToString);
			}
		}

		private HttpConfiguration CreateHttpConfiguration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			config.MapHttpAttributeRoutes();
			config.Services.Replace(typeof(ITraceWriter), new TraceWriter());
			config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
			config.Services.Replace(typeof(IHttpControllerActivator), _controlerActivator);
			//Пока пусть все
			//config.Filters.Add(new AuthorizationAttribute(app) { Roles = Settings.Default.Authorized });
			config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
			config.EnableSwagger(c => {
				c.SingleApiVersion("v0.1", "TestCaseDiffer API");
				c.OperationFilter<ExamplesOperationFilter>();
			}).EnableSwaggerUi();						

			return config;
		}

		private static void SetAuthentication(IAppBuilder appBuilder)
		{
			var listener = (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
			listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
		}
	}
}
