using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Orders_management.Models;

namespace Orders_management.Repository
{
    public class OrdersManagementContext : DbContext
    {
        public string ConnectionString { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public OrdersManagementContext(DbContextOptions<OrdersManagementContext> options):
            base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToContainer("OrderContainer")
                .HasPartitionKey(order => order.OrderCode);

            modelBuilder.Entity<Product>().ToContainer("ProductContainer")
                .HasPartitionKey(product => product.ProductCode);
        }
    }
}
