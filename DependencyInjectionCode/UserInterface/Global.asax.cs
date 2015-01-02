using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace UserInterface
{
    public class MvcApplication : System.Web.HttpApplication
    {
		// something is wrong with connecting to the site
		// poor man's di
		// this is how a container would be told to run.
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

	        var controllerFactory = new CommerceControllerFactory();

			ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

	    public static void RegisterRoutes(RouteCollection routes)
	    {
		    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("favicon.ico");

		    routes.MapRoute(
			    "Default",												// Route name
			    "{controller}/{action}/{id}",							// URL with parameters
			    new {controller = "Home", aciton = "Index", id = ""});	// Parameter defaults
	    }
    }
}
