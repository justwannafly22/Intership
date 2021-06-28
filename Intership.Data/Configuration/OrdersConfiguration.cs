using System;
using Intership.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intership.Data.Configuration
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    Id = new Guid("b2333228-6d8e-43ae-8009-95e64ea50938"),
                    Date = new DateTime(2021, 6, 8, 14, 35, 0),
                    Count = 1,
                    ClientId = new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"),
                    ProductId = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                    AdvancedInfo = "Advanced info is empty"
                },
                new Order
                {
                    Id = new Guid("0843b6af-8160-42e3-a65e-40a897851c8c"),
                    Date = new DateTime(2021, 6, 8, 14, 35, 15),
                    Count = 1,
                    ClientId = new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"),
                    ProductId = new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a"),
                    AdvancedInfo = "Advanced info is empty"
                },
                new Order
                {
                    Id = new Guid("5d96d2dc-c8be-4846-9066-da88f1d2934a"),
                    Date = new DateTime(2021, 6, 8, 14, 35, 30),
                    Count = 1,
                    ClientId = new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"),
                    ProductId = new Guid("95bdd46a-f616-4188-9f1a-3dc2eb1a3a64"),
                    AdvancedInfo = "Advanced info is empty"
                },
                new Order
                {
                    Id = new Guid("ac16b9e3-6bc2-43ee-b78f-7c7c2f3b084e"),
                    Date = new DateTime(2021, 6, 8, 11, 30, 0),
                    Count = 1,
                    ClientId = new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"),
                    ProductId = new Guid("23cbb20e-8174-4ab6-b32e-ee2010f19217"),
                    AdvancedInfo = "Advanced info is empty"
                },
                new Order //5;
                {
                    Id = new Guid("5ea3751a-a36a-480b-b6b1-f78947b70b19"),
                    Date = new DateTime(2021, 6, 8, 10, 10, 50),
                    Count = 1,
                    ClientId = new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"),
                    ProductId = new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0"),
                    AdvancedInfo = "Advanced info is empty"
                },
                new Order
                {
                    Id = new Guid("48784c17-efa4-41ab-9ff9-bdc676d7d20a"),
                    Date = new DateTime(2021, 6, 8, 15, 15, 37),
                    Count = 1,
                    ClientId = new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"),
                    ProductId = new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3"),
                    AdvancedInfo = "Advanced info is empty"
                },
                new Order
                {
                    Id = new Guid("cb63b643-b3c3-4043-a710-6d6d02f02be8"),
                    Date = new DateTime(2021, 6, 8, 9, 57, 13),
                    Count = 1,
                    ClientId = new Guid("c766948e-6e43-4c37-a340-71a06347376d"),
                    ProductId = new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"),
                    AdvancedInfo = "Advanced info is empty"
                },
                new Order
                {
                    Id = new Guid("6fdff5b9-69c9-4f4b-88fe-936968128ea2"),
                    Date = new DateTime(2021, 6, 7, 13, 27, 23),
                    Count = 1,
                    ClientId = new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"),
                    ProductId = new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda"),
                    AdvancedInfo = "Advanced info is empty"
                },
                new Order
                {
                    Id = new Guid("9c26b939-fb16-493e-954e-5efe09ebf11f"),
                    Date = new DateTime(2021, 6, 7, 5, 2, 45),
                    Count = 1,
                    ClientId = new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"),
                    ProductId = new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"),
                    AdvancedInfo = "Advanced info is empty"
                },
                new Order
                {
                    Id = new Guid("15b6e738-a210-40aa-97b0-58798f4339af"),
                    Date = new DateTime(2021, 6, 7, 23, 12, 4),
                    Count = 2,
                    ClientId = new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"),
                    ProductId = new Guid("cae134c8-1faf-4e65-b08d-864367afeb21"),
                    AdvancedInfo = "Advanced info is empty"
                }
            );
        }
    }
}
