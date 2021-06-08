using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class ClientsConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(
                new Client()
                {
                    Id = new Guid("4ed8b5d0-01cb-4c1c-921f-0a58dab32f69"),
                    Name = "Egor",
                    Surname = "Dubrovskiy",
                    Age = 20,
                    Email = "holcan@mail.ru",
                    ContactNumber = "+375 (29) 238-15-39"
                },
                new Client()
                {
                    Id = new Guid("c80a9219-4ff3-435a-be8a-3462482a73d9"),
                    Name = "Alexey",
                    Surname = "Voinovskiy",
                    Age = 20,
                    Email = "alex@mail.ru",
                    ContactNumber = "+375 (29) 123-45-67"
                },
                new Client()
                {
                    Id = new Guid("51032953-9150-4072-9a56-ea22906e799c"),
                    Name = "Stasik",
                    Surname = "Ignatenko",
                    Age = 20,
                    Email = "stasik@mail.ru",
                    ContactNumber = "+375 (29) 123-45-68"
                },
                new Client()
                {
                    Id = new Guid("2acefc95-a35c-4f0a-848a-665ab939e6b8"),
                    Name = "Igor",
                    Surname = "Igorev",
                    Age = 25,
                    Email = "lolkekchel@mail.ru",
                    ContactNumber = "+375 (29) 238-15-30"
                },
                new Client() // 5;
                {
                    Id = new Guid("1d40d73b-9f63-43f6-8eba-ef91d54f1f08"),
                    Name = "Maksim",
                    Surname = "Roflenov",
                    Age = 23,
                    Email = "rofl@mail.ru",
                    ContactNumber = "+375 (29) 238-15-12"
                },
                new Client()
                {
                    Id = new Guid("116f6c7f-cc8c-4526-a3d5-ca799bf440a2"),
                    Name = "Ivan",
                    Surname = "Laptopov",
                    Age = 20,
                    Email = "IvanUI4@mail.ru",
                    ContactNumber = "+375 (29) 238-15-32"
                },
                new Client()
                {
                    Id = new Guid("9ff78f1f-701d-4d30-a619-e0d9e5a4cb65"),
                    Name = "Masha",
                    Surname = "Mazurova",
                    Age = 38,
                    Email = "mazurova@mail.ru",
                    ContactNumber = "+375 (29) 238-15-24"
                },
                new Client()
                {
                    Id = new Guid("6beee7e9-8f29-4a6b-854b-98c87759cb2d"),
                    Name = "Dasha",
                    Surname = "Semenova",
                    Age = 20,
                    Email = "stomatolog@mail.ru",
                    ContactNumber = "+375 (29) 238-15-54"
                },
                new Client()
                {
                    Id = new Guid("c766948e-6e43-4c37-a340-71a06347376d"),
                    Name = "Polina",
                    Surname = "Gagarina",
                    Age = 35,
                    Email = "gagarina@mail.ru",
                    ContactNumber = "+375 (29) 238-44-39"
                },
                new Client()
                {
                    Id = new Guid("4987cad9-aabd-4cab-8ef2-cc2c6283da29"),
                    Name = "Pasha",
                    Surname = "Pavlov",
                    Age = 18,
                    Email = "pavlik@mail.ru",
                    ContactNumber = "+375 (29) 238-55-39"
                }
                );
        }
    }
}
