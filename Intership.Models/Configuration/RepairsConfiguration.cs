using System;
using Intership.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intership.Models.Configuration
{
    public class RepairsConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder.HasData(
                new Repair()
                {
                    Id = new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55"),
                    Name = "Fixing the problem"
                },
                new Repair()
                {
                    Id = new Guid("228aea49-4717-4bf9-9cf4-585b33e54629"),
                    Name = "Fixing the problem"
                },
                new Repair()
                {
                    Id = new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49"),
                    Name = "Fixing the problem"
                },
                new Repair()
                {
                    Id = new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb"),
                    Name = "Fixing the problem"
                },
                new Repair() //5;
                {
                    Id = new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761"),
                    Name = "Fixing the problem"
                },
                new Repair()
                {
                    Id = new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b"),
                    Name = "Fixing the problem"
                },
                new Repair()
                {
                    Id = new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de"),
                    Name = "Fixing the problem"
                },
                new Repair()
                {
                    Id = new Guid("04af2669-ed99-4517-9559-afd077ecd737"),
                    Name = "Fixing the problem"
                },
                new Repair()
                {
                    Id = new Guid("c016f3c3-5189-469a-a580-1798d88882ee"),
                    Name = "Fixing the problem"
                },
                new Repair()
                {
                    Id = new Guid("29b9d37c-3f23-4507-96b5-8506b291218b"),
                    Name = "Fixing the problem"
                }
            );
        }
    }
}
