using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Audiofile
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "UrzadzeniaSzczegoly",
              url: "urzadzenie-{id}.html",
              defaults: new { controller = "Urzadzenia", action = "Szczegoly" });


            routes.MapRoute(name: "UrzadzeniaLista",
                url: "Kategoria/{nazwa}.html",
                defaults: new { controller = "Urzadzenia", action = "Lista" });


            routes.MapRoute(name: "Stronystatyczne",
                url: "strony/{nazwa}.html",
                defaults: new { controller= "Home", action= "StronyStatyczne" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
