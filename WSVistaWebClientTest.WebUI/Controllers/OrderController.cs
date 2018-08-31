using System.Linq;
using System.Web.Mvc;
using WSVistaWebClientTest.Domain.Abstract;
using WSVistaWebClientTest.WebUI.Models;

namespace WSVistaWebClientTest.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private int PageSize = 3;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(int page = 1)
        {
            var model = new OrderListViewModel
            {
                Orders = _repository.Orders
                    .OrderBy(o => o.OrderId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new OrderListPagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Orders.Count()
                }
            };

            return View(model);
        }
    }
}