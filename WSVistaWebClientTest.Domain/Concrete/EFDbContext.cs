using System.Data.Entity;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Ticket> Tickets { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // configures one-to-many relationship
        //    modelBuilder.Entity<Ticket>()
        //        .HasRequired(t => t.Order)
        //        .WithMany(o => o.Tickets)
        //        .HasForeignKey(t => t.OrderId);
        //}
    }
}
