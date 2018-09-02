using System.Web.Mvc;
using System.Web.Routing;
using WSVistaWebClientTest.Domain.Entities;
using WSVistaWebClientTest.WebUI.Infrastructure.Binders;

namespace WSVistaWebClientTest.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Order), new CurrentOrderModelBinder());
            ModelBinders.Binders.Add(typeof(Plan), new PlanModelBinder());
        }
    }
}
