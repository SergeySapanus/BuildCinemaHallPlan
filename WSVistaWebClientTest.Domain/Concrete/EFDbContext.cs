using System.Data.Entity;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
