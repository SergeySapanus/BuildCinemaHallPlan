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

        private static PlanIndexViewModel CreateModel(SimplePlan currentSimplePlan, Order currentOrder)
        {
            var model = new PlanIndexViewModel
            {
                Plan = currentSimplePlan,
                Order = currentOrder
            };
            return model;
        }

        public ViewResult Index(SimplePlan currentSimplePlan, Order currentOrder)
        {
            return View(CreateModel(currentSimplePlan, currentOrder));
        }

        public RedirectToRouteResult AddTicket(SimplePlan currentSimplePlan, Order currentOrder, int seatCompositeId)
        {
            var ticket = new Ticket
            {
             
                Seat = currentSimplePlan.GetSeatsLayout()
                    .OfType<Seat>()
                    .FirstOrDefault(s => s.CompositeId == seatCompositeId)
            };

            currentOrder.Tickets.Add(ticket);

            return RedirectToAction("Index", CreateModel(currentSimplePlan, currentOrder));
        }

        public RedirectToRouteResult RemoveTicket(SimplePlan currentSimplePlan, Order currentOrder, int seatCompositeId)
        {
            var found = currentOrder.Tickets.FirstOrDefault(t => t.Seat.CompositeId == seatCompositeId);
            if (found != null)
                currentOrder.Tickets.Remove(found);

            return RedirectToAction("Index", CreateModel(currentSimplePlan, currentOrder));
        }

        [HttpPost]
        public ViewResult Checkout(SimplePlan currentSimplePlan, Order currentOrder)
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

            return View("Index", CreateModel(currentSimplePlan, currentOrder));
        }
    }
}