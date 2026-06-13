using ECommerce.Blazor;
using ECommerce.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var url = "https://localhost:7128/api";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });

// Register services
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
