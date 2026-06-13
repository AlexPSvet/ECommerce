using ECommerce.Core.Entities;
using ECommerce.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Api.Data.Seed
{
    public class ProductsSeed : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "Laptop",
                    Category = Category.Electronics,
                    Description = "High-performance laptop with 16GB RAM and 512GB SSD.",
                    Price = 999.99m,
                    Stock = 10
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "iPhone 15 Pro Max",
                    Category = Category.Electronics,
                    Description = "Latest smartphone with stunning display and powerful camera.",
                    Price = 799.99m,
                    Stock = 20
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Name = "Samsung Headphones",
                    Category = Category.Electronics,
                    Description = "Noise-cancelling headphones with superior sound quality.",
                    Price = 199.99m,
                    Stock = 15
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    Name = "Razer Laptop",
                    Category = Category.Electronics,
                    Description = "High-performance desktop computer with powerful graphics card.",
                    Price = 1499.99m,
                    Stock = 10
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000005"),
                    Name = "AirPods",
                    Category = Category.Electronics,
                    Description = "Wireless earbuds with high-quality sound and seamless connectivity.",
                    Price = 199.99m,
                    Stock = 15
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000006"),
                    Name = "Coffee Maker",
                    Category = Category.Home,
                    Description = "Brew the perfect cup of coffee with this easy-to-use coffee maker.",
                    Price = 49.99m,
                    Stock = 30
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000007"),
                    Name = "Air Fryer",
                    Category = Category.Home,
                    Description = "Cook your favorite meals with this easy-to-use air fryer.",
                    Price = 89.99m,
                    Stock = 20
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000008"),
                    Name = "Refrigerator",
                    Category = Category.Home,
                    Description = "Spacious and energy-efficient refrigerator for all your storage needs.",
                    Price = 499.99m,
                    Stock = 10
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000009"),
                    Name = "Oven",
                    Category = Category.Home,
                    Description = "Bake and roast your favorite dishes with this versatile oven.",
                    Price = 299.99m,
                    Stock = 15
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000010"),
                    Name = "Blender",
                    Category = Category.Home,
                    Description = "Blend your favorite ingredients with this powerful and easy-to-use blender.",
                    Price = 49.99m,
                    Stock = 30
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000011"),
                    Name = "Running Shoes",
                    Category = Category.Sports,
                    Description = "Lightweight running shoes designed for maximum comfort and performance.",
                    Price = 89.99m,
                    Stock = 25
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000012"),
                    Name = "Jersey",
                    Category = Category.Sports,
                    Description = "High-quality sports jersey for your favorite team.",
                    Price = 49.99m,
                    Stock = 25
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000013"),
                    Name = "Basketball",
                    Category = Category.Sports,
                    Description = "Official size and weight basketball for indoor and outdoor play.",
                    Price = 29.99m,
                    Stock = 20
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000014"),
                    Name = "FIFA World Cup Ball",
                    Category = Category.Sports,
                    Description = "Official FIFA World Cup match ball for professional play.",
                    Price = 89.99m,
                    Stock = 25
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000015"),
                    Name = "Mexico Jersey",
                    Category = Category.Sports,
                    Description = "Official Mexico national team jersey for fans and players.",
                    Price = 89.99m,
                    Stock = 25
                }
            );
        }
    }
}
