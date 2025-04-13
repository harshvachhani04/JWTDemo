using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JWTDemo.Migrations
{
    /// <inheritdoc />
    public partial class ProductsSampleData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "StockQuantity");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Ergonomic wireless mouse with USB nano receiver", 19.99m, "Wireless Mouse", 120 },
                    { 2, "Backlit mechanical keyboard with red switches", 59.99m, "Mechanical Keyboard", 75 },
                    { 3, "Full HD monitor with adjustable stand", 189.99m, "27-inch Monitor", 40 },
                    { 4, "Fast charging USB-C wall adapter", 24.99m, "USB-C Charger", 200 },
                    { 5, "Portable USB 3.0 hard drive", 69.99m, "External Hard Drive 1TB", 60 },
                    { 6, "Cooling pad with dual fans and adjustable height", 29.99m, "Laptop Cooling Pad", 95 },
                    { 7, "Wireless over-ear headphones with mic", 49.99m, "Bluetooth Headphones", 80 },
                    { 8, "1080p USB webcam with auto light correction", 39.99m, "HD Webcam", 50 },
                    { 9, "Adjustable desk stand for smartphones", 14.99m, "Smartphone Holder", 130 },
                    { 10, "Digital drawing tablet with pressure sensitivity", 89.99m, "Graphic Tablet", 25 },
                    { 11, "LED ring light for streaming and photography", 21.99m, "LED Ring Light", 70 },
                    { 12, "Compact wireless keyboard with silent keys", 27.99m, "Wireless Keyboard", 100 },
                    { 13, "High-speed USB 3.0 flash drive", 11.49m, "USB Flash Drive 64GB", 150 },
                    { 14, "In-ear earbuds with noise isolation", 34.99m, "Noise Cancelling Earbuds", 90 },
                    { 15, "Wired gaming mouse with DPI settings", 32.99m, "Gaming Mouse", 85 },
                    { 16, "Portable mini projector for home theater", 129.99m, "Mini Projector", 30 },
                    { 17, "Gold-plated HDMI cable, 4K compatible", 8.99m, "HDMI Cable 6ft", 180 },
                    { 18, "Water-resistant laptop sleeve with zipper", 18.99m, "Laptop Sleeve 15.6\"", 140 },
                    { 19, "Wi-Fi smart plug with Alexa and Google support", 22.49m, "Smart Plug", 110 },
                    { 20, "Waterproof speaker with deep bass", 35.99m, "Portable Bluetooth Speaker", 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "Quantity");
        }
    }
}
