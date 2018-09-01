using System;
using System.Linq;
using System.Web.Mvc;
using WSVistaWebClientTest.Domain.Abstract;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.WebUI.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanProcessor _planProcessor;
        private readonly IOrderRepository _orderRepository;

        public PlanController(IPlanProcessor planProcessor, IOrderRepository orderRepository)
        {
            _planProcessor = planProcessor;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult Plan()
        {
            _planProcessor.GetPlan();

            return View();
        }

        public RedirectToRouteResult AddTicket(Order currentOrder, Ticket ticket, string returnUrl)
        {
            currentOrder.Tickets.Add(ticket);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveTicket(Order currentOrder, Ticket ticket, string returnUrl)
        {
            currentOrder.Tickets.Remove(ticket);

            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public ViewResult Checkout(Order currentOrder, string returnUrl)
        {
            if (!currentOrder.Tickets.Any())
                ModelState.AddModelError(string.Empty, "Sorry, your order is empty!");

            if (ModelState.IsValid)
            {
                currentOrder.OrderNumber = Guid.NewGuid().ToString();
                currentOrder.OrderDate = DateTime.Now;

                _orderRepository.SaveOrder(currentOrder);

                currentOrder.Tickets.Clear();

                return View("Completed");
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}