using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WSVistaWebClientTest.Domain.Entities
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}