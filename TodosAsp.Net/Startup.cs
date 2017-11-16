using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodosAsp.Net.Models;

namespace TodosAsp.Net
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{

			WebApiConfig.Configure(app);
			TodosAsp.Net.App_Start.SimpleInjectorInitializer.Initialize();
			//config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
			Database.SetInitializer(new TodoDbInitializer());
		}
	}
}