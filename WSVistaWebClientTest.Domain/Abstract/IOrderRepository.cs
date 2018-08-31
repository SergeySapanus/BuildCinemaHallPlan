using System.Collections.Generic;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }

        void SaveOrder(Order order);
    }
}