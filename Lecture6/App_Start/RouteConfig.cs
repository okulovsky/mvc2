using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lecture6
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Filter",
                url: "Catalog/Filter",
                defaults: new { controller = "Catalog", action = "FilteredBooks" }
                );

            routes.MapRoute(
                name: "Catalog",
                url: "Catalog/{ViewName}",
                defaults: new { controller = "Catalog", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
