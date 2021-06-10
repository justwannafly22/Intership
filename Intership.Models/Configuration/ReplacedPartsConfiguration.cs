using System;
using Intership.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intership.Models.Configuration
{
    public class ReplacedPartsConfiguration : IEntityTypeConfiguration<ReplacedPart>
    {
        public void Configure(EntityTypeBuilder<ReplacedPart> builder)
        {
            builder.HasData(
                new ReplacedPart()
                {
                    Id = new Guid("2f6b761f-24a5-4f50-94b8-2a27b1f21823"),
                    Name = "Replacement part",
                    Price = 15,
                    Count = 1,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                    RepairId = new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55")
                },
                new ReplacedPart()
                {
                    Id = new Guid("4795f7f9-5c54-4426-9686-3bb27b9223a2"),
                    Name = "Replacement part",
                    Price = 20,
                    Count = 1,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("3af8f791-6c93-4afb-820d-3c8bccc83bc4"),
                    RepairId = new Guid("228aea49-4717-4bf9-9cf4-585b33e54629")
                },
                new ReplacedPart()
                {
                    Id = new Guid("d2ce0637-b66e-47ab-80f8-846ade723769"),
                    Name = "Replacement part",
                    Price = 25,
                    Count = 1,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("3fc64654-f1e8-4563-ad8f-98c4c56a548a"),
                    RepairId = new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49")
                },
                new ReplacedPart()
                {
                    Id = new Guid("477bd3bc-182a-4997-9a48-3cb419e5ce82"),
                    Name = "Replacement part",
                    Price = 10,
                    Count = 2,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                    RepairId = new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb")
                },
                new ReplacedPart() //5;
                {
                    Id = new Guid("0f65d970-5eb6-4e61-8630-a536dbe9fa98"),
                    Name = "Replacement part",
                    Price = 5,
                    Count = 3,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                    RepairId = new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761")
                },
                new ReplacedPart()
                {
                    Id = new Guid("882adfb5-628f-46fe-82da-44e91f5f4de9"),
                    Name = "Replacement part",
                    Price = 30,
                    Count = 2,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("d3bfdeae-ad9e-44e2-b666-52e758c19dda"),
                    RepairId = new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b")
                },
                new ReplacedPart()
                {
                    Id = new Guid("6ceb82ab-89b9-4a32-80c2-a6ac1c35c6e6"),
                    Name = "Replacement part",
                    Price = 2,
                    Count = 30,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("9def4539-eb0b-4f28-ac0c-d7f4d7e18de0"),
                    RepairId = new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de")
                },
                new ReplacedPart()
                {
                    Id = new Guid("b188a871-578f-41f8-8769-2f045028c464"),
                    Name = "Replacement part",
                    Price = 7.5,
                    Count = 3,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("e357485f-cddd-4c92-8de7-702918e2bda8"),
                    RepairId = new Guid("04af2669-ed99-4517-9559-afd077ecd737")
                },
                new ReplacedPart()
                {
                    Id = new Guid("e41aeec6-b638-4e13-ab30-92fdc681721c"),
                    Name = "Replacement part",
                    Price = 1.5,
                    Count = 50,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("cae134c8-1faf-4e65-b08d-864367afeb21"),
                    RepairId = new Guid("c016f3c3-5189-469a-a580-1798d88882ee")
                },
                new ReplacedPart()
                {
                    Id = new Guid("0cc0c42d-a52c-411e-9ffa-983acc519854"),
                    Name = "Replacement part",
                    Price = 8.25,
                    Count = 3,
                    AdvancedInfo = "Advanced info is empty",
                    ProductId = new Guid("338afc0c-7290-4c15-a5f5-cb091dea6ad3"),
                    RepairId = new Guid("29b9d37c-3f23-4507-96b5-8506b291218b")
                }
            );
        }
    }
}
