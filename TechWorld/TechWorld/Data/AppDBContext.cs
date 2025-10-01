using Microsoft.EntityFrameworkCore;
using TechWorld.Models;

namespace TechWorld.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        // Model sets
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Precision for money values
            builder.Entity<Product>()
                   .Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Entity<Order>()
                   .Property(o => o.Discount)
                   .HasColumnType("decimal(18,2)");

            builder.Entity<Order>()
                   .Property(o => o.Total)
                   .HasColumnType("decimal(18,2)");

            // Customer - Order: One-to-Many
            builder.Entity<Order>()
                   .HasOne(o => o.Customer)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(o => o.CustomerId);

            // Product - Order: Many-to-Many
            builder.Entity<Order>()
                   .HasMany(o => o.Products)
                   .WithMany(p => p.Orders);
        }
    }
}
