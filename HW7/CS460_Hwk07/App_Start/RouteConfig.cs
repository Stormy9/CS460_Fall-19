using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CS460_Hwk07
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //===========================================================================
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //===========================================================================
            routes.MapRoute(
                name: "User",
                url: "api/user",
                defaults: new { controller = "Home", action = "User", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Repo",
                url: "api/repo",
                defaults: new { controller = "Home", action = "Repos", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Commits",
                url: "api/commits",
                defaults: new { controller = "Home", action = "Commits", id = UrlParameter.Optional }
            );
            //===========================================================================
        }
    }
}
