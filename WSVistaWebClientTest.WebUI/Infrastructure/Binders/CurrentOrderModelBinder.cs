using System.Collections.Generic;
using System.Web.Mvc;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.WebUI.Infrastructure.Binders
{
    public class CurrentOrderModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Order currentOrder = null;

            if (controllerContext.HttpContext.Session != null)
                currentOrder = (Order)controllerContext.HttpContext.Session[nameof(currentOrder)];

            if (currentOrder == null)
            {
                currentOrder = new Order();
                currentOrder.Tickets = new List<Ticket>();

                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[nameof(currentOrder)] = currentOrder;
            }

            return currentOrder;
        }
    }
}