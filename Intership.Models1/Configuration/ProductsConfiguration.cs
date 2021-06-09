using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(//all prices in dollars;
                new Product 
                { 
                    Id = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                    Name = "Teapot",
                    Price = 20,
                    Description = "Default teapot"
                },
                new Product
                {
                    Id = new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"),
                    Name = "Electric stove",
                    Price = 500,
                    Description = "Height - 85cm, width - 50cm"
                },
                new Product
                {
                    Id = new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a"),
                    Name = "Vacuum cleaner",
                    Price = 80,
                    Description = "Dust container volume - 0.8l"
                },
                new Product
                {
                    Id = new Guid("95bdd46a-f616-4188-9f1a-3dc2eb1a3a64"),
                    Name = "Coffee machine",
                    Price = 925,
                    Description = "Power - 1450w"
                },
                new Product //5;
                {
                    Id = new Guid("23cbb20e-8174-4ab6-b32e-ee2010f19217"),
                    Name = "Personal computer",
                    Price = 1000,
                    Description = "Personal computer for games and comfortable work"
                },
                new Product
                {
                    Id = new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda"),
                    Name = "Laptop",
                    Price = 750,
                    Description = "Laptop for work and lowpower games"
                },
                new Product 
                { 
                    Id = new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0"),
                    Name = "Monitor",
                    Price = 125,
                    Description = "Diagonal - 12,5 inches, resolution - 1920x1080p"
                },
                new Product
                {
                    Id = new Guid("e357485f-cddd-4c92-8de7-702918e2bda8"),
                    Name = "Keyboard",
                    Price = 40,
                    Description = "Keydoard has a RGB-backlight"
                },
                new Product
                {
                    Id = new Guid("cae134c8-1faf-4e65-b08d-864367afeb21"),
                    Name = "Computer mouse",
                    Price = 20,
                    Description = "Shelf life - 10000 clicks"
                },
                new Product //10;
                {
                    Id = new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3"),
                    Name = "Headphones",
                    Price = 50,
                    Description = "Active noise cancellation"
                }
            );
        }
    }
}
