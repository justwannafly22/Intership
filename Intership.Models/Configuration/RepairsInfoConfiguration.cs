using System;
using Intership.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intership.Models.Configuration
{
    public class RepairsInfoConfiguration : IEntityTypeConfiguration<RepairInfo>
    {
        public void Configure(EntityTypeBuilder<RepairInfo> builder)
        {
            builder.HasData(
                new RepairInfo()
                {
                    Id = new Guid("8a0d3ba9-0381-4ecd-8f08-a44b8a012c99"),
                    Date = new DateTime(2021, 6, 9, 13, 22, 12),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32"),
                    RepairId = new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55")
                },
                new RepairInfo()
                {
                    Id = new Guid("df698265-4600-4233-a43b-a14cefa0ce84"),
                    Date = new DateTime(2021, 6, 12, 21, 32, 23),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32"),
                    RepairId = new Guid("228aea49-4717-4bf9-9cf4-585b33e54629")
                },
                new RepairInfo()
                {
                    Id = new Guid("7103bcce-ef4c-438d-bb7b-54843bc5876f"),
                    Date = new DateTime(2021, 6, 22, 21, 56, 46),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32"),
                    RepairId = new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49")
                },
                new RepairInfo()
                {
                    Id = new Guid("ce657751-0172-404c-bee1-86577748fda7"),
                    Date = new DateTime(2021, 6, 17, 12, 40, 40),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb"),
                    RepairId = new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb")
                },
                new RepairInfo() //5;
                {
                    Id = new Guid("06ed2ac8-bd78-49e5-8541-6c05fca1c900"),
                    Date = new DateTime(2021, 6, 15, 23, 40, 30),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb"),
                    RepairId = new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761")
                },
                new RepairInfo()
                {
                    Id = new Guid("a806068a-828d-48c3-b708-08db47019bd0"),
                    Date = new DateTime(2021, 6, 12, 11, 1, 45),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32"),
                    RepairId = new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b")
                },
                new RepairInfo()
                {
                    Id = new Guid("aa2b4994-3cde-4bf9-af01-53c98b2d3d79"),
                    Date = new DateTime(2021, 6, 9, 16, 23, 59),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791"),
                    RepairId = new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de")
                },
                new RepairInfo()
                {
                    Id = new Guid("d6f5f6bf-3576-490f-afa8-03aa30bf19f4"),
                    Date = new DateTime(2021, 6, 19, 14, 56, 50),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791"),
                    RepairId = new Guid("04af2669-ed99-4517-9559-afd077ecd737")
                },
                new RepairInfo()
                {
                    Id = new Guid("7042b0f5-de40-4ad8-be74-0af196e3e219"),
                    Date = new DateTime(2021, 6, 17, 15, 20, 10),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("cbdfc5bd-82a6-4a8f-b8ec-71a3279f2e07"),
                    RepairId = new Guid("c016f3c3-5189-469a-a580-1798d88882ee")
                },
                new RepairInfo()
                {
                    Id = new Guid("cb75f4fb-676f-4722-b298-a5f1ba86684e"),
                    Date = new DateTime(2021, 6, 23, 17, 30, 20),
                    AdvancedInfo = "Advanced info is empty",
                    StatusId = new Guid("23ea6ac5-a0a1-4da2-9102-5e7c472aa663"),
                    RepairId = new Guid("29b9d37c-3f23-4507-96b5-8506b291218b")
                }
            );
        }
    }
}
