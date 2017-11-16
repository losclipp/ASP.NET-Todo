using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using TodosAsp.Net.Repository;
using TodosAsp.Net.Services;
using TodosAsp.Net.Controllers;

namespace TodosAsp.Net.App_Start
{

	public class SimpleInjectorInitializer
	{
		public static void Initialize()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			// Register your types, for instance using the scoped lifestyle:
			InitializeContainer(container);

			// This is an extension method from the integration package.

			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			container.Verify();
			GlobalConfiguration.Configuration.DependencyResolver =	new SimpleInjectorWebApiDependencyResolver(container);
		}

		private static void InitializeContainer(Container container)
		{
			container.Register<ITodoService, TodoService>( Lifestyle.Scoped);
			container.Register< ITodoRepository, TodoRepository>(Lifestyle.Scoped);
		}
	}
}