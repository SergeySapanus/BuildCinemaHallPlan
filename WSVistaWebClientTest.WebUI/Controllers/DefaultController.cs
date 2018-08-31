using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSVistaWebClientTest.WebUI.Infrastructure.Concrete;

namespace WSVistaWebClientTest.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public ViewResult Index(MenuItemType item)
        {
            switch (item)
            {
                case MenuItemType.Plan:
                    return View(null);
                case MenuItemType.Orders:
                    return View(null);
                default:
                    throw new ArgumentException(nameof(item));
            }
        }
    }
}