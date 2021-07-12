using AutoMapper;
using Intership.Data.Entities;
using Intership.Data.Parameters;
using Intership.Models.RequestModels.Client;
using Intership.Models.ResponseModels;
using Intership.Services;
using Intership.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Intership.Tests.Tests
{
    public class ClientServiceTests
    {
        private readonly IMapper _mapper;
        public ClientServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAsync_Response_WithoutRepairs()
        {
            var guid = Guid.NewGuid();

            var repository = new ClientFakeRepository();
            repository.Mock.Setup(s => s.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Client()
                {
                    Id = guid,
                    Name = "Kek",
                    Surname = "Kekov",
                    Age = 18,
                    ContactNumber = "+375 (29) 123-45-67",
                    Email = "kekov@mail.ru",
                    AllowEmailNotification = false
                });

            var service = new ClientService(repository.Repository, _mapper);

            var client = await service.GetAsync(guid);

            Assert.NotNull(client);
            Assert.Equal(guid, client.Id);
            Assert.Equal("Kek Kekov", client.FullName);
            Assert.Equal(18, client.Age);
            Assert.Equal("+375 (29) 123-45-67", client.ContactNumber);
            Assert.Equal("kekov@mail.ru", client.Email);
            Assert.False(client.AllowEmailNotification);
        }

        [Fact]
        public async Task GetAllAsync_Response_WithoutRepairs()
        {
            var guid = Guid.NewGuid();

            var expected = new List<Client>() 
            { 
                new Client() 
                {
                    Id = guid,
                    Name = "Kek",
                    Surname = "Kekov",
                    Age = 18,
                    ContactNumber = "+375 (29) 123-45-67",
                    Email = "kekov@mail.ru",
                    AllowEmailNotification = false
                }
            };

            var repository = new ClientFakeRepository();
            repository.Mock.Setup(s => s.GetAllAsync())
                .ReturnsAsync(expected);

            var service = new ClientService(repository.Repository, _mapper);

            var clients = await service.GetAllAsync();

            Assert.NotNull(clients);
            Assert.Equal(expected[0].Id, clients[0].Id);
            Assert.Equal($"{expected[0].Name} {expected[0].Surname}", clients[0].FullName);
            Assert.Equal(expected[0].Age, clients[0].Age);
            Assert.Equal(expected[0].ContactNumber, clients[0].ContactNumber);
            Assert.Equal(expected[0].Email, clients[0].Email);
            Assert.Equal(expected[0].AllowEmailNotification, clients[0].AllowEmailNotification);
        }

        [Fact]
        public async Task UpdateAsync_Response_ShouldReturnId()
        {
            var clientId = Guid.NewGuid();

            var fakeRepository = new ClientFakeRepository();
            fakeRepository.Mock.Setup(s => s.UpdateAsync(It.IsAny<Guid>(), It.IsAny<ClientParameter>()))
                .ReturnsAsync(clientId);

            var service = new ClientService(fakeRepository.Repository, _mapper);

            var response = await service.UpdateAsync(clientId, new UpdateClientModel()
            {
                Name = "Vutin",
                Surname = "Por",
                Age = 18,
                ContactNumber = "+375 (29) 123-45-67",
                Email = "kekov@mail.ru",
                AllowEmailNotification = false
            });

            Assert.Equal(clientId, response);
        }

        [Fact]
        public async Task CreateAsync_Response_ShouldReturnId()
        {
            var clientId = Guid.NewGuid();

            var fakeRepository = new ClientFakeRepository();
            fakeRepository.Mock.Setup(s => s.CreateAsync(It.IsAny<ClientParameter>()))
                .ReturnsAsync(clientId);

            var service = new ClientService(fakeRepository.Repository, _mapper);

            var response = await service.CreateAsync(new AddClientModel()
            {
                Name = "Vutin",
                Surname = "Por",
                Age = 18,
                ContactNumber = "+375 (29) 123-45-67",
                Email = "kekov@mail.ru",
                AllowEmailNotification = false
            });

            Assert.Equal(clientId, response);
        }

        [Fact]
        public async Task DeleteAsync_Response_ShouldDeleteClient()
        {
            var clientId = Guid.NewGuid();

            var fakeRepository = new ClientFakeRepository();
            fakeRepository.Mock.Setup(s => s.DeleteAsync(It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);

            var service = new ClientService(fakeRepository.Repository, _mapper);

            await service.DeleteAsync(clientId);
        }

        [Fact]
        public async Task GetRepairs_Response_ShouldReturnRepairs()
        {
            var clientId = Guid.NewGuid();
            var repairId = Guid.NewGuid();
            var repairInfoId = Guid.NewGuid();

            var fakeRepository = new ClientFakeRepository();
            fakeRepository.Mock.Setup(s => s.GetWithRepairsAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Client()
                {
                    Id = clientId,
                    Name = "Vutin",
                    Surname = "Por",
                    Age = 18,
                    ContactNumber = "+375 (29) 123-45-67",
                    Email = "kekov@mail.ru",
                    AllowEmailNotification = false,
                    Repairs = new List<Repair>
                    {
                        new Repair()
                        {
                            Id = repairId,
                            Name = "name",
                            RepairInfoId = repairInfoId
                        }
                    }
                });

            var service = new ClientService(fakeRepository.Repository, _mapper);

            var repairs = await service.GetRepairs(clientId);

            Assert.NotNull(repairs);
            Assert.Equal(repairId, repairs[0].Id);
            Assert.Equal("name", repairs[0].Name);
            Assert.Equal(repairInfoId, repairs[0].RepairInfoId);
        }
    }
}
