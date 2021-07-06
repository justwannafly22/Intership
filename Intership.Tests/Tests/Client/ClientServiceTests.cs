using AutoMapper;
using Intership.Services;
using Intership.Tests.Mocks.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using Entities = Intership.Data.Entities;

namespace Intership.Tests.Tests.Client
{
    [TestClass]
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

        //[TestMethod]
        //public async Task GetClientsAsync_Response_WithoutRepairs()
        //{
        //    var repository = new ClientFakeRepository();
        //    repository.Mock.Setup(s => s.GetAllAsync())
        //}

        [TestMethod]
        public async Task GetClientAsync_Response_WithoutRepairs()
        {
            var guid = Guid.NewGuid().ToString();

            var repository = new ClientFakeRepository();
            repository.Mock.Setup(s => s.GetAsync(It.IsAny<Guid>(), false))
                .Returns(Task.FromResult(new Entities.Client()
                {
                    Id = Guid.Parse(guid),
                    Name = "Kek",
                    Surname = "Kekov",
                    Age = 18,
                    ContactNumber = "+375 (29) 123-45-67",
                    Email = "kekov@mail.ru",
                    AllowEmailNotification = false
                }));

            var service = new ClientService(repository.Repository, _mapper);

            var client = await service.GetAsync(Guid.Parse(guid));

            Assert.IsNotNull(client);
            Assert.AreEqual(Guid.Parse(guid), client.Id);
            Assert.AreEqual("Kek Kekov", client.FullName);
            Assert.AreEqual(18, client.Age);
            Assert.AreEqual("+375 (29) 123-45-67", client.ContactNumber);
            Assert.AreEqual("kekov@mail.ru", client.Email);
            Assert.AreEqual(false, client.AllowEmailNotification);
        }
    }
}
