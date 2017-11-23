using Castle.MicroKernel;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace TestCaseDiffer.Service.Windsor
{
	public class WindsorControllerActivator : IHttpControllerActivator
	{
		private readonly IKernel _container;
		private readonly ILogger _log = LogManager.GetCurrentClassLogger();

		public WindsorControllerActivator(IKernel container)
		{
			_container = container;
		}

		public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
		{
			var controller = _container.Resolve(controllerType);
			request.RegisterForDispose(new Release(() => _container.ReleaseComponent(controller)));
			return (IHttpController)controller;
		}

		private class Release : IDisposable
		{
			private readonly Action _release;

			public Release(Action release)
			{
				_release = release;
			}

			public void Dispose()
			{
				_release();
			}
		}
	}
}
