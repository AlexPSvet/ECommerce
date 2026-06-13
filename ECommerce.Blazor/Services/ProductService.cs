using ECommerce.Core.Models;
using ECommerce.Core.Enums;
using System.Net.Http.Json;
using ECommerce.Core.DTOs.Product;

namespace ECommerce.Blazor.Services;

public class ProductService(HttpClient httpClient) : IProductService
{
    public async Task<PagedResult<ProductDetailsDto>?> GetProductsAsync(int page = 1, int pageSize = 10)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<PagedResult<ProductDetailsDto>>($"/api/products?page={page}&pageSize={pageSize}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching products: {ex.Message}");
            return null;
        }
    }

    public async Task<PagedResult<ProductDetailsDto>?> GetProductsBySectionAsync(Category category, int page = 1, int pageSize = 10)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<PagedResult<ProductDetailsDto>>($"/api/products?category={category}&page={page}&pageSize={pageSize}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching products for category {category}: {ex.Message}");
            return null;
        }
    }

    public async Task<ProductDetailsDto?> GetProductByIdAsync(Guid id)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<ProductDetailsDto>($"/api/products/{id}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching product {id}: {ex.Message}");
            return null;
        }
    }
}
