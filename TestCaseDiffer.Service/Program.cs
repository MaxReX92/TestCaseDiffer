using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.Owin.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer.Tfs;
using Topshelf;
using Topshelf.HostConfigurators;

namespace TestCaseDiffer.Service
{
	class Program
	{
		private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

		private static int Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
			TaskScheduler.UnobservedTaskException += UnobservedTaskException;

			using (var container = new WindsorContainer())
			{
				try
				{
					container.Register(Component.For<IChangesProvider>().ImplementedBy<PreparedChangesProvider>());
					//container.Register(Component.For<IChangesProvider>().ImplementedBy<TfsApiChangesProvider>());
					container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
					container.Install(FromAssembly.This());
					return (int)HostFactory.Run(hostConfigurator => Configure<TestCaseDifferService>(hostConfigurator, container));
				}
				catch (Exception ex)
				{
					_logger.Fatal(ex);
					return -1;
				}
			}
		}

		private static void Configure<T>(HostConfigurator hostConfigurator, IWindsorContainer container)
			where T : TestCaseDifferService
		{
			hostConfigurator.UseNLog();
			hostConfigurator.Service<T>(serviceConfigurator =>
			{
				serviceConfigurator.ConstructUsing(() => container.Resolve<T>(new { appStart = (AppStarter)WebApp.Start }));
				serviceConfigurator.WhenStarted(service => service.Start());
				serviceConfigurator.WhenStopped(service => service.Stop());
			});
		}

		private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			_logger.Fatal("Unhandled exception : " + e.ExceptionObject);
		}

		private static void UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			_logger.Fatal("Unobserved task exception : " + e.Exception);
		}
	}
}
