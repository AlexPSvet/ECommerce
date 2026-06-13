using ECommerce.Core.Enums;

namespace ECommerce.Core.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Category Category { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
