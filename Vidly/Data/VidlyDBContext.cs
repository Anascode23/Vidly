using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class VidlyDBContext : DbContext
    {
        public VidlyDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
               new Customer { Id = 1, Name = "Sarah" },
               new Customer { Id = 2, Name = "Jack" },
               new Customer { Id = 3, Name = "Marry" }
               );
        }
    }
}