using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Api.Data.Seed
{
    public class OrderItemsSeed : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            var order1Id = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var order2Id = Guid.Parse("00000000-0000-0000-0000-000000000002");

            builder.HasData(
                new() { 
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), 
                    OrderId = order1Id, 
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000001"), 
                    Quantity = 1, 
                    UnitPrice = 999.99m 
                },
                new() { 
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    OrderId = order1Id, 
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000002"), 
                    Quantity = 2,
                    UnitPrice = 29.99m 
                },
                new() { 
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), 
                    OrderId = order1Id, 
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000003"), 
                    Quantity = 1,
                    UnitPrice = 79.99m 
                },
                new() {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    OrderId = order2Id,
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Quantity = 1, 
                    UnitPrice = 399.99m 
                },
                new() { 
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), 
                    OrderId = order2Id, 
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000005"), 
                    Quantity = 1, 
                    UnitPrice = 59.99m 
                }
            );
        }
    }
}
