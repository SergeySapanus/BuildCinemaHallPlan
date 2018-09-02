using System.Collections.Generic;
using System.Data.Entity;
using WSVistaWebClientTest.Domain.Abstract;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Order> OrdersLazy => _context.Orders;

        public IEnumerable<Order> Orders
        {
            get { return _context.Orders.Include(order => order.Tickets); }
        }

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}