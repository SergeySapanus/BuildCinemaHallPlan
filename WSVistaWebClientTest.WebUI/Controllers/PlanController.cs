using System;
using System.Linq;
using System.Web.Mvc;
using WSVistaWebClientTest.Domain.Abstract;
using WSVistaWebClientTest.Domain.Entities;
using WSVistaWebClientTest.WebUI.Models;

namespace WSVistaWebClientTest.WebUI.Controllers
{
    public class PlanController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public PlanController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ViewResult Index(Plan currentPlan, Order currentOrder)
        {
            var model = new PlanIndexViewModel
            {
                Plan = currentPlan,
                Order = currentOrder
            };

            return View(model);
        }

        public ViewResult AddTicket(Plan currentPlan, Order currentOrder, Ticket ticket)
        {
            currentOrder.Tickets.Add(ticket);

            return View("Index");
        }

        public ViewResult RemoveTicket(Plan currentPlan, Order currentOrder, Ticket ticket)
        {
            currentOrder.Tickets.Remove(ticket);

            return View("Index");
        }

        [HttpPost]
        public ViewResult Checkout(Plan currentPlan, Order currentOrder)
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

            return View("Index");
        }
    }
}