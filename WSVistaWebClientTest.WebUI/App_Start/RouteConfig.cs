using System.Web.Mvc;
using System.Web.Routing;
using WSVistaWebClientTest.WebUI.Infrastructure.Concrete;

namespace WSVistaWebClientTest.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: string.Empty,
                defaults: new { controller = "Default", action = "Index", menuItem = MenuItemType.Plan }
            );

            routes.MapRoute(
                name: null,
                url: $"{MenuItemType.Orders}",
                defaults: new { controller = "Default", action = "Index", page = 1, menuItem = MenuItemType.Orders }
            );

            routes.MapRoute(
                name: null,
                url: $"{MenuItemType.Plan}",
                defaults: new { controller = "Plan", action = "Plan", menuItem = MenuItemType.Plan }
            );

            routes.MapRoute(
                name: null,
                url: $"{MenuItemType.Orders}/Page{{page}}",
                defaults: new { controller = "Order", action = "List", page = "\\d+", menuItem = MenuItemType.Orders }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Default", action = "Index" }
            );
        }
    }
}
