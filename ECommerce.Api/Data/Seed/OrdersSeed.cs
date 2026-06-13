using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Api.Data.Seed
{
    public class OrdersSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var order1Id = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var order2Id = Guid.Parse("00000000-0000-0000-0000-000000000002");

            builder.HasData(
                new() { 
                    Id = order1Id, 
                    CreatedAt = new DateTime(2024, 1, 1), 
                    TotalAmount = 1 
                },
                new() { 
                    Id = order2Id, 
                    CreatedAt = new DateTime(2024, 1, 2), 
                    TotalAmount = 1 
                }
            );
        }
    }
}
