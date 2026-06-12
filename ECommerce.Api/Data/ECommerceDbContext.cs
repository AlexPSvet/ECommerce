using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Price).HasPrecision(18, 2);
            });

            // Configure Order entity
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalAmount).HasPrecision(18, 2);
                entity.HasMany(e => e.OrderItems)
                    .WithOne(e => e.Order)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure OrderItem entity
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed some sample data
            var products = new List<Product>
            {
                new() { Id = Guid.NewGuid(), Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, Stock = 10 },
                new() { Id = Guid.NewGuid(), Name = "Mouse", Description = "Wireless mouse", Price = 29.99m, Stock = 50 },
                new() { Id = Guid.NewGuid(), Name = "Keyboard", Description = "Mechanical keyboard", Price = 79.99m, Stock = 30 },
                new() { Id = Guid.NewGuid(), Name = "Monitor", Description = "4K Monitor 27 inch", Price = 399.99m, Stock = 15 },
                new() { Id = Guid.NewGuid(), Name = "Webcam", Description = "HD Webcam", Price = 59.99m, Stock = 25 }
            };

            var order1Id = Guid.NewGuid();
            var order2Id = Guid.NewGuid();

            var orderItems1 = new List<OrderItem>
            {
                new() { Id = Guid.NewGuid(), OrderId = order1Id, ProductId = products[0].Id, Quantity = 1, UnitPrice = products[0].Price },
                new() { Id = Guid.NewGuid(), OrderId = order1Id, ProductId = products[1].Id, Quantity = 2, UnitPrice = products[1].Price },
                new() { Id = Guid.NewGuid(), OrderId = order1Id, ProductId = products[2].Id, Quantity = 1, UnitPrice = products[2].Price }
            };

            var orderItems2 = new List<OrderItem>
            {
                new() { Id = Guid.NewGuid(), OrderId = order2Id, ProductId = products[3].Id, Quantity = 1, UnitPrice = products[3].Price },
                new() { Id = Guid.NewGuid(), OrderId = order2Id, ProductId = products[4].Id, Quantity = 1, UnitPrice = products[4].Price }
            };

            var orders = new List<Order>
            {
                new() { Id = order1Id, CreatedAt = DateTime.UtcNow, TotalAmount = orderItems1.Sum(oi => oi.Quantity * oi.UnitPrice) },
                new() { Id = order2Id, CreatedAt = DateTime.UtcNow, TotalAmount = orderItems2.Sum(oi => oi.Quantity * oi.UnitPrice)  }
            };

            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<OrderItem>().HasData(orderItems1);
            modelBuilder.Entity<OrderItem>().HasData(orderItems2);
            modelBuilder.Entity<Order>().HasData(orders);
        }
    }
}
