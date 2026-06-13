using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.DTOs.Product
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Range(0, (double) decimal.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
