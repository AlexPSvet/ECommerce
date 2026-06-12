using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.DTOs
{
    public class ProductDetailsDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        [Range(0, (double) decimal.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
