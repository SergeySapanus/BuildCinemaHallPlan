using System.Collections.Generic;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.WebUI.Models
{
    public class OrderListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public OrderListPagingInfo PagingInfo { get; set; }
    }
}