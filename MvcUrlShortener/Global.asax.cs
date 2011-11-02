using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcUrlShortener
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default", // Route name
                "", // URL with parameters
                new { controller = "Shortener", action = "ShortenUrl", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Review", // Route name
                ".review/{id}", // URL with parameters
                new { controller = "Shortener", action = "ReviewUlr", id = UrlParameter.Optional } // Parameter defaults
            );


            routes.MapRoute(
                "Redirect", // Route name
                "{encodedId}", // URL with parameters
                new { controller = "Shortener", action = "RedirectUrl", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            RegisterRoutes(RouteTable.Routes);
        }
    }
}