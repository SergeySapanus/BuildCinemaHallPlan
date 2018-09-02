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
            Plan currentPlan = null;

            if (controllerContext.HttpContext.Session != null)
                currentPlan = (Plan)controllerContext.HttpContext.Session[nameof(currentPlan)];

            if (currentPlan == null)
            {
                var appSetting = ConfigurationManager.AppSettings["Plan.Api"];
                currentPlan = new PlanProcessor(appSetting).GetPlan();

                if (currentPlan.ResponseCode != 0)
                    throw new Exception($"The plan is not valid! ({nameof(currentPlan.ResponseCode)}: {currentPlan.ResponseCode})");

                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[nameof(currentPlan)] = currentPlan;
            }

            return currentPlan;
        }
    }
}