using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace thewayshop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Filter",
                url: "Product/{typeId}",
                defaults: new {controller = "Product", action = "Filter", typeId = "jacket"}
            );

            routes.MapRoute(
                name: "Product Search",
                url: "Product/Search/{keyword}",
                defaults: new {controller = "Product", action = "Search"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}