using ECommerce.Core.DTOs;
using ECommerce.Core.Models;

namespace ECommerce.Blazor.Services;

public interface IProductService
{
    Task<PagedResult<ProductDetailsDto>?> GetProductsAsync(int page = 1, int pageSize = 10);
    Task<ProductDetailsDto?> GetProductByIdAsync(Guid id);
}
