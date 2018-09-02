using System;
using System.Configuration;
using System.Web.Mvc;
using WSVistaWebClientTest.Domain.Concrete;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.WebUI.Infrastructure.Binders
{
    public class PlanModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            SimplePlan currentSimplePlan = null;

            if (controllerContext.HttpContext.Session != null)
                currentSimplePlan = (SimplePlan)controllerContext.HttpContext.Session[nameof(currentSimplePlan)];

            if (currentSimplePlan == null)
            {
                var appSetting = ConfigurationManager.AppSettings["Plan.Api"];
                var plan = new PlanProcessor(appSetting).GetPlan();

                if (plan.ResponseCode != 0)
                    throw new Exception($"The plan is not valid! ({nameof(plan.ResponseCode)}: {plan.ResponseCode})");

                currentSimplePlan = new SimplePlan(plan);

                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[nameof(currentSimplePlan)] = currentSimplePlan;
            }

            return currentSimplePlan;
        }
    }
}