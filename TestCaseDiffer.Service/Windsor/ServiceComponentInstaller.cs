using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace TestCaseDiffer.Service.Windsor
{
	public class ServiceComponentInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),
				Classes.FromAssemblyInThisApplication().Pick().WithService.AllInterfaces()
			);
		}
	}
}
