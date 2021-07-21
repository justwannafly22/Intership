using Intership.Controllers;
using Intership.Models.RequestModels.Client;
using Intership.Models.ResponseModels;
using Intership.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Intership.Tests.Tests
{
    public class ClientControllerTests
    {
        [Fact]
        public async Task Create_ValidModel_ShouldReturnOK()
        {
            var clientId = Guid.NewGuid();
            
            var fakeService = new ClientFakeService();
            fakeService.Mock.Setup(s => s.CreateAsync(It.IsAny<AddClientModel>()))
                .ReturnsAsync(new ClientResponseModel()
                {
                    FullName = "Vutin Por",
                    Age = 18,
                    ContactNumber = "+375 (29) 123-45-67",
                    Email = "kekov@mail.ru",
                    AllowEmailNotification = false
                });

            var controller = new ClientController(fakeService.Service);

            var response = await controller.Create(new AddClientModel()
            {
                Name = "Kek",
                Surname = "Kekov",
                Age = 18,
                ContactNumber = "+375 (29) 123-45-67",
                Email = "kekov@mail.ru",
                AllowEmailNotification = false
            });

            Assert.NotNull(response);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(response);

            Assert.Equal((int)HttpStatusCode.Created, createdAtActionResult.StatusCode);

            Assert.NotNull(createdAtActionResult.Value);
            var addedResponse = Assert.IsType<ClientResponseModel>(createdAtActionResult.Value);

            Assert.NotNull(addedResponse);
            Assert.Equal("Vutin Por", addedResponse.FullName);
            Assert.Equal(18, addedResponse.Age);
            Assert.Equal("+375 (29) 123-45-67", addedResponse.ContactNumber);
            Assert.Equal("kekov@mail.ru", addedResponse.Email);
            Assert.False(addedResponse.AllowEmailNotification);
        }

        [Fact]
        public async Task Create_NullModel_ShouldThrowNullArgumentException()
        {
            var fakeService = new ClientFakeService();
            fakeService.Mock.Setup(s => s.CreateAsync(It.IsAny<AddClientModel>()))
                .ThrowsAsync(new ArgumentNullException(nameof(AddClientModel)));

            var controller = new ClientController(fakeService.Service);

            try
            {
                var response = await controller.Create(null).ConfigureAwait(false);
            }
            catch (ArgumentNullException ex)
            {
                Assert.Equal(nameof(AddClientModel), ex.ParamName);
            }
        }

        [Fact]
        public async Task Update_ValidModel_ShouldReturnOK()
        {
            var clientId = Guid.NewGuid();

            var fakeService = new ClientFakeService();
            fakeService.Mock.Setup(s => s.UpdateAsync(It.IsAny<Guid>(), It.IsAny<UpdateClientModel>()))
                .ReturnsAsync(clientId);
            fakeService.Mock.Setup(s => s.IsExist(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var controller = new ClientController(fakeService.Service);

            var response = await controller.Update(clientId, new UpdateClientModel()
            {
                Name = "Kek",
                Surname = "Kekov",
                Age = 23,
                ContactNumber = "+375 (29) 123-45-67",
                Email = "kekov@mail.ru",
                AllowEmailNotification = false
            });

            Assert.NotNull(response);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(response);

            Assert.Equal("Get", redirectToActionResult.ActionName);
            Assert.Equal(clientId, redirectToActionResult.RouteValues["id"]);
        }
        
        [Fact]
        public async Task GetAll_WithData_ShouldReturnOk()
        {
            var clientId = Guid.NewGuid();

            var fakeService = new ClientFakeService();
            fakeService.Mock.Setup(s => s.GetAllAsync())
                .ReturnsAsync(new List<ClientResponseModel>()
                {
                    new ClientResponseModel()
                    {
                        Id = clientId,
                        FullName = "Vutin por",
                        Age = 23,
                        ContactNumber = "+375 (29) 123-45-67",
                        Email = "kekov@mail.ru",
                        AllowEmailNotification = false
                    }
                });

            var controller = new ClientController(fakeService.Service);

            var response = await controller.GetAll();

            Assert.NotNull(response);
            var okObjectResult = Assert.IsType<OkObjectResult>(response);

            Assert.NotNull(okObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult.StatusCode);
            var clients = Assert.IsType<List<ClientResponseModel>>(okObjectResult.Value);

            Assert.NotNull(clients);
            Assert.NotEmpty(clients);
            Assert.Equal(clientId, clients[0].Id);
            Assert.Equal("Vutin por", clients[0].FullName);
            Assert.Equal(23, clients[0].Age);
            Assert.Equal("+375 (29) 123-45-67", clients[0].ContactNumber);
            Assert.False(clients[0].AllowEmailNotification);
        }
        
        [Fact]
        public async Task GetAll_NoData_ShouldReturnOk()
        {
            var clientId = Guid.NewGuid();

            var fakeService = new ClientFakeService();
            fakeService.Mock.Setup(s => s.GetAllAsync())
                .ReturnsAsync(new List<ClientResponseModel>());

            var controller = new ClientController(fakeService.Service);

            var response = await controller.GetAll();

            Assert.NotNull(response);
            var okObjectResult = Assert.IsType<OkObjectResult>(response);

            Assert.NotNull(okObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult.StatusCode);
            var clients = Assert.IsType<List<ClientResponseModel>>(okObjectResult.Value);

            Assert.NotNull(clients);
            Assert.Empty(clients);
        }
        
        [Fact]
        public async Task Get_ValidId_ShouldReturnOk()
        {
            var clientId = Guid.NewGuid();

            var fakeService = new ClientFakeService();
            fakeService.Mock.Setup(s => s.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new ClientResponseModel()
                {
                    Id = clientId,
                    FullName = "Vutin por",
                    Age = 23,
                    ContactNumber = "+375 (29) 123-45-67",
                    Email = "kekov@mail.ru",
                    AllowEmailNotification = false
                });

            var controller = new ClientController(fakeService.Service);

            var response = await controller.Get(clientId);

            Assert.NotNull(response);
            var okObjectResult = Assert.IsType<OkObjectResult>(response);

            Assert.NotNull(okObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult.StatusCode);

            var client = Assert.IsType<ClientResponseModel>(okObjectResult.Value);

            Assert.NotNull(client);
            Assert.Equal(clientId, client.Id);
            Assert.Equal("Vutin por", client.FullName);
            Assert.Equal(23, client.Age);
            Assert.Equal("+375 (29) 123-45-67", client.ContactNumber);
            Assert.False(client.AllowEmailNotification);
        }

        [Fact]
        public async Task Delete_ValidId_ShouldReturnNoContent()
        {
            var clientId = Guid.NewGuid();

            var fakeService = new ClientFakeService();
            fakeService.Mock.Setup(s => s.IsExist(It.IsAny<Guid>()))
                .ReturnsAsync(true);
            fakeService.Mock.Setup(s => s.DeleteAsync(It.IsAny<Guid>()));

            var controller = new ClientController(fakeService.Service);

            var response = await controller.Delete(clientId);

            Assert.NotNull(response);
            var noContentResult = Assert.IsType<NoContentResult>(response);

            Assert.NotNull(noContentResult);
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }
        
        [Fact]
        public async Task Delete_InvalidId_ShouldReturnNotFound()
        {
            var clientId = Guid.NewGuid();

            var fakeService = new ClientFakeService();
            fakeService.Mock.Setup(s => s.IsExist(It.IsAny<Guid>()))
                .ReturnsAsync(false);
            fakeService.Mock.Setup(s => s.DeleteAsync(It.IsAny<Guid>()));

            var controller = new ClientController(fakeService.Service);

            var response = await controller.Delete(clientId);

            Assert.NotNull(response);
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(response);

            Assert.NotNull(notFoundObjectResult);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundObjectResult.StatusCode);
        }
    }
}
