using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projekt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Adminowe1",
                url: "admin/produkty/{action}/{id}",
                defaults: new { controller = "Produkts", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Adminowe2",
                url: "admin/uzytkownicy/{action}/{id}",
                defaults: new { controller = "Uzytkowniks", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
