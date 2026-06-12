using ECommerce.Api.Data;
using ECommerce.Core.Models;
using ECommerce.Core.DTOs;
using ECommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ECommerceDbContext _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ECommerceDbContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Get paginated list of products
        // @param pageNumber : Page number (default: 1)
        // @param pageSize : Page size (default: 10, max: 100)
        // @returns : Paginated list of products
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResult<Product>>> GetProducts(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("Getting products - Page: {PageNumber}, Size: {PageSize}", pageNumber, pageSize);

            if (pageNumber < 1)
                pageNumber = 1;

            if (pageSize < 1)
                pageSize = 10;

            if (pageSize > 100)
                pageSize = 100;

            var totalCount = await _context.Products.CountAsync();

            var products = await _context.Products
                .OrderBy(p => p.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(product => new ProductDetailsDto()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Stock = product.Stock
                })
                .ToListAsync();

            var result = new PagedResult<ProductDetailsDto>
            {
                Items = products,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(result);
        }

        // Get product by ID
        // @param id : Product ID
        // @returns : Product details
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            _logger.LogInformation("Getting product with ID: {ProductId}", id);

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                _logger.LogWarning("Product with ID {ProductId} not found", id);
                return NotFound();
            }

            return Ok(product);
        }

        // Create a new product
        // @param product : Product details
        // @returns : Created product
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDetailsDto productDto)
        {
            _logger.LogInformation("Creating new product: {ProductName}", productDto.Name);

            var product = new Product()
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Update an existing product
        // @param id : Product ID
        // @param product : Updated product details
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDetailsDto productDto)
        {
            _logger.LogInformation("Updating product with ID: {ProductId}", id);

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                _logger.LogWarning("Product with ID {ProductId} not found", id);
                return NotFound();
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            existingProduct.Stock = productDto.Stock;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // Delete a product
        // @param id : Product ID
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            _logger.LogInformation("Deleting product with ID: {ProductId}", id);

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                _logger.LogWarning("Product with ID {ProductId} not found", id);
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> ProductExists(Guid id)
        {
            return await _context.Products.AnyAsync(e => e.Id == id);
        }
    }
}
