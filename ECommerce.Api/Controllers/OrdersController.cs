using ECommerce.Api.Data;
using ECommerce.Core.Models;
using ECommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Core.DTOs;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ECommerceDbContext _context;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ECommerceDbContext context, ILogger<OrdersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Get all orders with pagination
        // @param pageNumber : Page number (default: 1)
        // @param pageSize : Page size (default: 10, max: 100)
        // @returns : Paginated list of orders
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<Order>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResult<Order>>> GetOrders(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("Getting orders - Page: {PageNumber}, Size: {PageSize}", pageNumber, pageSize);

            if (pageNumber < 1)
                pageNumber = 1;

            if (pageSize < 1)
                pageSize = 10;

            if (pageSize > 100)
                pageSize = 100;

            var totalCount = await _context.Orders.CountAsync();

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(order => new OrderDto()
                {
                    TotalAmount = order.TotalAmount,
                    CreatedAt = order.CreatedAt,
                    Items = order.OrderItems.Select(oi => new OrderItemDto
                    {
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice
                    }).ToList()
                })
                .ToListAsync();

            var result = new PagedResult<OrderDto>
            {
                Items = orders,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(result);
        }

        // Get an order by ID
        // @param id : Order ID
        // @returns : Order details
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id)
        {
            _logger.LogInformation("Getting order with ID: {OrderId}", id);

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                _logger.LogWarning("Order with ID {OrderId} not found", id);
                return NotFound();
            }

            var orderDto = new OrderDto
            {
                TotalAmount = order.TotalAmount,
                CreatedAt = order.CreatedAt,
                Items = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };

            return Ok(orderDto);
        }

        // Create a new order
        // @param order : Order details
        // @returns : Created order
        [HttpPost]
        [ProducesResponseType(typeof(Order), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] Order order)
        {
            _logger.LogInformation("Creating new order");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            order.Id = Guid.NewGuid();
            order.CreatedAt = DateTime.UtcNow;

            foreach (var item in order.OrderItems)
            {
                item.Id = Guid.NewGuid();
                item.OrderId = order.Id;
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderDto = new OrderDto
            {
                TotalAmount = order.TotalAmount,
                CreatedAt = order.CreatedAt,
                Items = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, orderDto);
        }

        // Delete an order
        // @param id : Order ID
        // @returns : No content
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            _logger.LogInformation("Deleting order with ID: {OrderId}", id);

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                _logger.LogWarning("Order with ID {OrderId} not found", id);
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
