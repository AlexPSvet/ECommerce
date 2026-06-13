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
                    ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?q=80&w=1471&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 999.99m,
                    Stock = 10
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "iPhone 15 Pro Max",
                    Category = Category.Electronics,
                    Description = "Latest smartphone with stunning display and powerful camera.",
                    ImageUrl = "https://images.unsplash.com/photo-1695048132832-b41495f12eb4?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 799.99m,
                    Stock = 20
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Name = "Samsung Headphones",
                    Category = Category.Electronics,
                    Description = "Noise-cancelling headphones with superior sound quality.",
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1679513691485-711d030f7e94?q=80&w=1413&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 199.99m,
                    Stock = 15
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    Name = "Razer Laptop",
                    Category = Category.Electronics,
                    Description = "High-performance desktop computer with powerful graphics card.",
                    ImageUrl = "https://images.unsplash.com/photo-1600861195091-690c92f1d2cc?q=80&w=1480&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 1499.99m,
                    Stock = 10
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000005"),
                    Name = "AirPods",
                    Category = Category.Electronics,
                    Description = "Wireless earbuds with high-quality sound and seamless connectivity.",
                    ImageUrl = "https://images.unsplash.com/photo-1572569511254-d8f925fe2cbb?q=80&w=1289&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 199.99m,
                    Stock = 15
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000006"),
                    Name = "Coffee Maker",
                    Category = Category.Home,
                    Description = "Brew the perfect cup of coffee with this easy-to-use coffee maker.",
                    ImageUrl = "https://images.unsplash.com/photo-1707241358597-bafcc8a8e73d?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 49.99m,
                    Stock = 30
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000007"),
                    Name = "Air Fryer",
                    Category = Category.Home,
                    Description = "Cook your favorite meals with this easy-to-use air fryer.",
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1672192166833-c8ae84e5e127?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 89.99m,
                    Stock = 20
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000008"),
                    Name = "Refrigerator",
                    Category = Category.Home,
                    Description = "Spacious and energy-efficient refrigerator for all your storage needs.",
                    ImageUrl = "https://images.unsplash.com/photo-1630459065645-549fe5a56db4?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 499.99m,
                    Stock = 10
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000009"),
                    Name = "Oven",
                    Category = Category.Home,
                    Description = "Bake and roast your favorite dishes with this versatile oven.",
                    ImageUrl = "https://images.unsplash.com/photo-1565357253897-79d691886a73?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 299.99m,
                    Stock = 15
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000010"),
                    Name = "Blender",
                    Category = Category.Home,
                    Description = "Blend your favorite ingredients with this powerful and easy-to-use blender.",
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1718043036199-d98bef36af46?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 49.99m,
                    Stock = 30
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000011"),
                    Name = "Running Shoes",
                    Category = Category.Sports,
                    Description = "Lightweight running shoes designed for maximum comfort and performance.",
                    ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 89.99m,
                    Stock = 25
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000012"),
                    Name = "Jersey",
                    Category = Category.Sports,
                    Description = "High-quality sports jersey for your favorite team.",
                    ImageUrl = "https://images.unsplash.com/photo-1580149959184-c3aaa501a0d4?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 49.99m,
                    Stock = 25
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000013"),
                    Name = "Basketball",
                    Category = Category.Sports,
                    Description = "Official size and weight basketball for indoor and outdoor play.",
                    ImageUrl = "https://images.unsplash.com/photo-1627627256672-027a4613d028?q=80&w=1474&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 29.99m,
                    Stock = 20
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000014"),
                    Name = "FIFA World Cup Ball",
                    Category = Category.Sports,
                    Description = "Official FIFA World Cup match ball for professional play.",
                    ImageUrl = "https://images.unsplash.com/photo-1518091043644-c1d4457512c6?q=80&w=1331&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Price = 89.99m,
                    Stock = 25
                },
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000015"),
                    Name = "Mexico Jersey",
                    Category = Category.Sports,
                    Description = "Official Mexico national team jersey for fans and players.",
                    ImageUrl = "https://assets.adidas.com/images/w_600,f_auto,q_auto/bda1f02220bc47e0b3e1f8b3e34d25f6_9366/Jersey_Local_Seleccion_Nacional_de_Mexico_26_Manga_Larga_Version_Jugador_Verde_KA3998_HM53.jpg",
                    Price = 89.99m,
                    Stock = 25
                }
            );
        }
    }
}
