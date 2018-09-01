using System.Collections.Generic;
using WSVistaWebClientTest.Domain.Abstract;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Order> Orders => _context.Orders;

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}