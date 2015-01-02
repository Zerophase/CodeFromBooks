using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc;
using OSIM.Core.Persistence;
using OSIM.Core.Services;

namespace MvcApplication1
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MvcApplication : NinjectHttpApplication
	{
		protected override void OnApplicationStarted()
		{
			base.OnApplicationStarted();

			AreaRegistration.RegisterAllAreas();
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "ItemType", action = "Index", id = UrlParameter.Optional });
		}

		protected override IKernel CreateKernel()
		{
			return new StandardKernel(new PersistenceModule(), new CoreServiceModule());
		}
		//protected override void Application_Start()
		//{
		//	base.
		//	AreaRegistration.RegisterAllAreas();

		//	WebApiConfig.Register(GlobalConfiguration.Configuration);
		//	FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
		//	RouteConfig.RegisterRoutes(RouteTable.Routes);
		//}
	}
}