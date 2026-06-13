using ECommerce.Core.DTOs;
using ECommerce.Core.Models;
using System.Net.Http.Json;

namespace ECommerce.Blazor.Services;

public class ProductService(HttpClient httpClient) : IProductService
{
    public async Task<PagedResult<ProductDetailsDto>?> GetProductsAsync(int page = 1, int pageSize = 10)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<PagedResult<ProductDetailsDto>>($"/products?page={page}&pageSize={pageSize}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching products: {ex.Message}");
            return null;
        }
    }

    public async Task<ProductDetailsDto?> GetProductByIdAsync(Guid id)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<ProductDetailsDto>($"/products/{id}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching product {id}: {ex.Message}");
            return null;
        }
    }
}
