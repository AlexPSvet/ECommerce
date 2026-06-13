using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "TotalAmount",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "TotalAmount",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Description",
                value: "High-performance laptop with 16GB RAM and 512GB SSD.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Latest smartphone with stunning display and powerful camera.", "iPhone 15 Pro Max", 799.99m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Noise-cancelling headphones with superior sound quality.", "Samsung Headphones", 199.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "High-performance desktop computer with powerful graphics card.", "Razer Laptop", 1499.99m, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Wireless earbuds with high-quality sound and seamless connectivity.", "AirPods", 199.99m, 15 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000006"), 4, "Brew the perfect cup of coffee with this easy-to-use coffee maker.", "Coffee Maker", 49.99m, 30 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 4, "Cook your favorite meals with this easy-to-use air fryer.", "Air Fryer", 89.99m, 20 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 4, "Spacious and energy-efficient refrigerator for all your storage needs.", "Refrigerator", 499.99m, 10 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 4, "Bake and roast your favorite dishes with this versatile oven.", "Oven", 299.99m, 15 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 4, "Blend your favorite ingredients with this powerful and easy-to-use blender.", "Blender", 49.99m, 30 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), 7, "Lightweight running shoes designed for maximum comfort and performance.", "Running Shoes", 89.99m, 25 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), 7, "High-quality sports jersey for your favorite team.", "Jersey", 49.99m, 25 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 7, "Official size and weight basketball for indoor and outdoor play.", "Basketball", 29.99m, 20 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), 7, "Official FIFA World Cup match ball for professional play.", "FIFA World Cup Ball", 89.99m, 25 },
                    { new Guid("00000000-0000-0000-0000-000000000015"), 7, "Official Mexico national team jersey for fans and players.", "Mexico Jersey", 89.99m, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "TotalAmount",
                value: 1139.96m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "TotalAmount",
                value: 459.98m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Description",
                value: "High-performance laptop");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Wireless mouse", "Mouse", 29.99m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "Mechanical keyboard", "Keyboard", 79.99m, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "4K Monitor 27 inch", "Monitor", 399.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Description", "Name", "Price", "Stock" },
                values: new object[] { "HD Webcam", "Webcam", 59.99m, 25 });
        }
    }
}
