using System.Web.Mvc;
using WSVistaWebClientTest.Domain.Abstract;

namespace WSVistaWebClientTest.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List()
        {
            return View(_repository.Orders);
        }
    }
}