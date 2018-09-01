using System;
using System.Web.Mvc;
using WSVistaWebClientTest.WebUI.Infrastructure.Concrete;

namespace WSVistaWebClientTest.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public RedirectToRouteResult Index(MenuItemType menuItem)
        {
            switch (menuItem)
            {
                case MenuItemType.Plan:
                    return RedirectToAction("Plan", "Plan");
                case MenuItemType.Orders:
                    return RedirectToAction("List", "Order");
                default:
                    throw new ArgumentException(nameof(menuItem));
            }
        }
    }
}