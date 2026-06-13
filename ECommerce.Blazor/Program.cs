using ECommerce.Blazor;
using ECommerce.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Get API URL from configuration (appsettings.json)
var apiUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7128/";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

// Register services
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
