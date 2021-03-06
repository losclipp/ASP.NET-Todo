﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;
using TodosAsp.Net.Models;
using System.Data.Entity;
using SimpleInjector.Integration.WebApi;
using SimpleInjector;

namespace TodosAsp.Net
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();
			config.EnableCors();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.Formatters.Remove(config.Formatters.XmlFormatter);


		}
		public static void Configure(IAppBuilder app)
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
	}
}
