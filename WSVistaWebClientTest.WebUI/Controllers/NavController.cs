using System.Web.Mvc;
using WSVistaWebClientTest.WebUI.Infrastructure.Abstract;
using WSVistaWebClientTest.WebUI.Infrastructure.Concrete;

namespace WSVistaWebClientTest.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IMenuInfo _menuInfo;

        public NavController(IMenuInfo menuInfo)
        {
            _menuInfo = menuInfo;
        }

        public PartialViewResult Menu(MenuItemType menuItem = MenuItemType.None)
        {
            ViewBag.SelectedLink = menuItem;

            return PartialView(_menuInfo.Items);
        }
    }
}