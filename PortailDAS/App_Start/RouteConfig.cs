using System.Web.Mvc;
using System.Web.Routing;

namespace PortailDAS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Accueil", action = "Accueil", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Elearning",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Elearning", action = "Elearning", id = UrlParameter.Optional }
            );
        }
    }
}
