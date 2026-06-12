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

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
