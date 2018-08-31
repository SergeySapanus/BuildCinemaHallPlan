using System;
using System.Collections.Generic;

namespace WSVistaWebClientTest.Domain.Entities
{
    public class Order
    {
        public long OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
    }
}