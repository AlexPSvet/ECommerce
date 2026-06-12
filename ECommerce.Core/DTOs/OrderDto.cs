namespace ECommerce.Core.DTOs
{
    public class OrderDto
    {
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemDto> Items { get; set; } = [];
    }
}
