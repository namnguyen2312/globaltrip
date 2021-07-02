using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NBT.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "cmsGtrip",
                url: "cmsGtrip",
                defaults: new { controller = "Admin", action = "Index", alias = UrlParameter.Optional },
                namespaces: new string[] { "NBT.Web.Controllers" }
            );
            routes.MapRoute(
                name: "visa",
                url: "visa/{alias}",
                defaults: new { controller = "Visa", action = "Index", alias = UrlParameter.Optional },
                namespaces: new string[] { "NBT.Web.Controllers" }
            );
            routes.MapRoute(
                name: "TourDetail",
                url: "tour/detail/{alias}",
                defaults: new { controller = "Tour", action = "Detail", alias = UrlParameter.Optional },
                namespaces: new string[] { "NBT.Web.Controllers" }
            );
            routes.MapRoute(
                name: "TicketDetail",
                url: "ticket/detail/{alias}",
                defaults: new { controller = "Ticket", action = "Detail", alias = UrlParameter.Optional },
                namespaces: new string[] { "NBT.Web.Controllers" }
            );
            routes.MapRoute(
                name: "BlogDetail",
                url: "blog/detail/{alias}",
                defaults: new { controller = "Blog", action = "Detail", alias = UrlParameter.Optional },
                namespaces: new string[] { "NBT.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] {"NBT.Web.Controllers" }
            );
        }
    }
}
