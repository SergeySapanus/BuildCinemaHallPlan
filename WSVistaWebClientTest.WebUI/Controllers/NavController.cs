using System.Web.Mvc;
using WSVistaWebClientTest.WebUI.Infrastructure.Abstract;

namespace WSVistaWebClientTest.WebUI.Controllers
{
    public class NavController : Controller
    {
        public PartialViewResult Menu(IMenuInfo menuInfo)
        {
            return PartialView(menuInfo.Items);
        }
    }
}