using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.DTOs
{
    public class OrderItemDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
