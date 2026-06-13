namespace ECommerce.Core.DTOs.Product
{
    public class ProductDetailsDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public string? Category { get; set; }

        public string Description { get; init; } = string.Empty;

        public decimal Price { get; init; }

        public int Stock { get; init; }

        public bool InStock => Stock > 0;

        public string? ImageUrl { get; init; }

        public DateTime CreatedAt { get; init; }
    }
}
