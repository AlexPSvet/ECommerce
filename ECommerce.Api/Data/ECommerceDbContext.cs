using ECommerce.Core.Entities;
using ECommerce.Core.Enums;
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
                entity.Property(e => e.Category).HasDefaultValue(Category.Other);
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
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Laptop", Category = Category.Electronics, Description = "High-performance laptop", Price = 999.99m, Stock = 10 },
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Mouse", Category = Category.Electronics, Description = "Wireless mouse", Price = 29.99m, Stock = 50 },
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Keyboard", Category = Category.Electronics, Description = "Mechanical keyboard", Price = 79.99m, Stock = 30 },
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Monitor", Category = Category.Electronics, Description = "4K Monitor 27 inch", Price = 399.99m, Stock = 15 },
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Webcam", Category = Category.Electronics, Description = "HD Webcam", Price = 59.99m, Stock = 25 }
            };

            var order1Id = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var order2Id = Guid.Parse("00000000-0000-0000-0000-000000000002");

            var orderItems1 = new List<OrderItem>
            {
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), OrderId = order1Id, ProductId = products[0].Id, Quantity = 1, UnitPrice = products[0].Price },
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), OrderId = order1Id, ProductId = products[1].Id, Quantity = 2, UnitPrice = products[1].Price },
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), OrderId = order1Id, ProductId = products[2].Id, Quantity = 1, UnitPrice = products[2].Price }
            };

            var orderItems2 = new List<OrderItem>
            {
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), OrderId = order2Id, ProductId = products[3].Id, Quantity = 1, UnitPrice = products[3].Price },
                new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), OrderId = order2Id, ProductId = products[4].Id, Quantity = 1, UnitPrice = products[4].Price }
            };

            var orders = new List<Order>
            {
                new() { Id = order1Id, CreatedAt = new DateTime(2024, 1, 1), TotalAmount = orderItems1.Sum(oi => oi.Quantity * oi.UnitPrice) },
                new() { Id = order2Id, CreatedAt = new DateTime(2024, 1, 2), TotalAmount = orderItems2.Sum(oi => oi.Quantity * oi.UnitPrice)  }
            };

            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<OrderItem>().HasData(orderItems1);
            modelBuilder.Entity<OrderItem>().HasData(orderItems2);
            modelBuilder.Entity<Order>().HasData(orders);
        }
    }
}
