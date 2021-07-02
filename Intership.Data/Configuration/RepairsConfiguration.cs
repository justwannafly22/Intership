using System;
using Intership.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intership.Data.Configuration
{
    public class RepairsConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder.HasData(
                new Repair()
                {
                    Id = new Guid("b70d7e3e-35c7-4c24-acda-1472ae0c1d55"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("4ed8b5d0-01cb-4c1c-921f-0a58dab32f69")
                },
                new Repair()
                {
                    Id = new Guid("228aea49-4717-4bf9-9cf4-585b33e54629"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("c80a9219-4ff3-435a-be8a-3462482a73d9")
                },
                new Repair()
                {
                    Id = new Guid("260e7b03-cf9e-4824-8e3d-174f6fb73e49"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("51032953-9150-4072-9a56-ea22906e799c")
                },
                new Repair()
                {
                    Id = new Guid("7478668c-1c7a-47ad-82c8-48c3744a1fdb"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8")
                },
                new Repair() //5;
                {
                    Id = new Guid("7d844508-2b92-4fe5-afc8-5e05382b9761"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08")
                },
                new Repair()
                {
                    Id = new Guid("633693ac-2891-4fa9-99e9-ffbb9d33aa4b"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2")
                },
                new Repair()
                {
                    Id = new Guid("530f0ff1-2d7e-4be0-80e3-77453658c9de"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65")
                },
                new Repair()
                {
                    Id = new Guid("04af2669-ed99-4517-9559-afd077ecd737"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d")
                },
                new Repair()
                {
                    Id = new Guid("c016f3c3-5189-469a-a580-1798d88882ee"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("c766948e-6e43-4c37-a340-71a06347376d")
                },
                new Repair()
                {
                    Id = new Guid("29b9d37c-3f23-4507-96b5-8506b291218b"),
                    Name = "Fixing the problem",
                    ClientId = new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29")
                }
            );
        }
    }
}
