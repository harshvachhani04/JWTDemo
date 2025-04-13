using JWTDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDemo>().HasData(
            new List<UserDemo>
            {
               new UserDemo
               {
                   UserId = 1,
                   Username = "admin",
                   Password = "admin",
                   Role = "admin"
               },
               new UserDemo
               {
                   UserId = 2,
                   Username = "User1",
                   Password = "1",
                   Role = "user"
               }
            });
            modelBuilder.Entity<Product>().HasData(
                    new List<Product>
                    {
                        new Product { ProductId = 1, ProductName = "Wireless Mouse", Price = 19.99m, Description = "Ergonomic wireless mouse with USB nano receiver", StockQuantity = 120 },
                        new Product { ProductId = 2, ProductName = "Mechanical Keyboard", Price = 59.99m, Description = "Backlit mechanical keyboard with red switches", StockQuantity = 75 },
                        new Product { ProductId = 3, ProductName = "27-inch Monitor", Price = 189.99m, Description = "Full HD monitor with adjustable stand", StockQuantity = 40 },
                        new Product { ProductId = 4, ProductName = "USB-C Charger", Price = 24.99m, Description = "Fast charging USB-C wall adapter", StockQuantity = 200 },
                        new Product { ProductId = 5, ProductName = "External Hard Drive 1TB", Price = 69.99m, Description = "Portable USB 3.0 hard drive", StockQuantity = 60 },
                        new Product { ProductId = 6, ProductName = "Laptop Cooling Pad", Price = 29.99m, Description = "Cooling pad with dual fans and adjustable height", StockQuantity = 95 },
                        new Product { ProductId = 7, ProductName = "Bluetooth Headphones", Price = 49.99m, Description = "Wireless over-ear headphones with mic", StockQuantity = 80 },
                        new Product { ProductId = 8, ProductName = "HD Webcam", Price = 39.99m, Description = "1080p USB webcam with auto light correction", StockQuantity = 50 },
                        new Product { ProductId = 9, ProductName = "Smartphone Holder", Price = 14.99m, Description = "Adjustable desk stand for smartphones", StockQuantity = 130 },
                        new Product { ProductId = 10, ProductName = "Graphic Tablet", Price = 89.99m, Description = "Digital drawing tablet with pressure sensitivity", StockQuantity = 25 },
                        new Product { ProductId = 11, ProductName = "LED Ring Light", Price = 21.99m, Description = "LED ring light for streaming and photography", StockQuantity = 70 },
                        new Product { ProductId = 12, ProductName = "Wireless Keyboard", Price = 27.99m, Description = "Compact wireless keyboard with silent keys", StockQuantity = 100 },
                        new Product { ProductId = 13, ProductName = "USB Flash Drive 64GB", Price = 11.49m, Description = "High-speed USB 3.0 flash drive", StockQuantity = 150 },
                        new Product { ProductId = 14, ProductName = "Noise Cancelling Earbuds", Price = 34.99m, Description = "In-ear earbuds with noise isolation", StockQuantity = 90 },
                        new Product { ProductId = 15, ProductName = "Gaming Mouse", Price = 32.99m, Description = "Wired gaming mouse with DPI settings", StockQuantity = 85 },
                        new Product { ProductId = 16, ProductName = "Mini Projector", Price = 129.99m, Description = "Portable mini projector for home theater", StockQuantity = 30 },
                        new Product { ProductId = 17, ProductName = "HDMI Cable 6ft", Price = 8.99m, Description = "Gold-plated HDMI cable, 4K compatible", StockQuantity = 180 },
                        new Product { ProductId = 18, ProductName = "Laptop Sleeve 15.6\"", Price = 18.99m, Description = "Water-resistant laptop sleeve with zipper", StockQuantity = 140 },
                        new Product { ProductId = 19, ProductName = "Smart Plug", Price = 22.49m, Description = "Wi-Fi smart plug with Alexa and Google support", StockQuantity = 110 },
                        new Product { ProductId = 20, ProductName = "Portable Bluetooth Speaker", Price = 35.99m, Description = "Waterproof speaker with deep bass", StockQuantity = 60 }
                    }
                );
            modelBuilder.Entity<Cart>().HasData(
                new List<Cart>
                {
                    new Cart
                    {
                        CartId = 1,
                        UserId = 1,
                        CreatedAt = new DateTime(2024, 12, 1, 10, 0, 0),
                    },
                    new Cart
                    {
                        CartId = 2,
                        UserId = 2,
                        CreatedAt = new DateTime(2024, 12, 1, 10, 0, 0),
                    },
                    new Cart
                    {
                        CartId = 3,
                        UserId = 3,
                        CreatedAt = new DateTime(2024, 12, 1, 10, 0, 0),
                    }
                });
            modelBuilder.Entity<CartItem>().HasData(
                new List<CartItem>
                {
                    new CartItem { CartItemId = 1, CartId = 1, ProductId = 2, Quantity = 1 }, // Mechanical Keyboard
                    new CartItem { CartItemId = 2, CartId = 1, ProductId = 5, Quantity = 2 },  // External Hard Drive
	                new CartItem { CartItemId = 3, CartId = 2, ProductId = 1, Quantity = 1 }, // Wireless Mouse
	                new CartItem { CartItemId = 4, CartId = 2, ProductId = 8, Quantity = 1 }, // HD Webcam
	                new CartItem { CartItemId = 5, CartId = 2, ProductId = 3, Quantity = 1 },   // 27-inch Monitor
	                new CartItem { CartItemId = 6, CartId = 3, ProductId = 10, Quantity = 1 }, // Graphic Tablet
	                new CartItem { CartItemId = 7, CartId = 3, ProductId = 13, Quantity = 3 }  // USB Flash Drive
                });

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(ci => ci.Items)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);
        }
        public DbSet<UserDemo> TblUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
