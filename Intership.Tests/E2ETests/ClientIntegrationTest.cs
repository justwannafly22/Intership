using AutoFixture;
using FluentAssertions;
using Intership.Data.Entities;
using Intership.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Intership.Tests.E2ETests
{
    public class ClientIntegrationTest : MSSQL_IntergationTests<Startup>, IClassFixture<MSSQL_WebApplicationFactory<Startup>>
    {
        private readonly Fixture _fixture;

        public ClientIntegrationTest(MSSQL_WebApplicationFactory<Startup> factory) : base(factory)
        {
            _fixture = new Fixture();
            _fixture.Customize<Client>(composer =>
                composer.Without(c => c.Repairs));
        }

        /// <summary>
        /// Method to construct a test entity that could be used in a test
        /// </summary>
        /// <returns></returns>
        private Client ConstructClient()
        {
            var entity = _fixture.Create<Client>();

            entity.Name = "1407test";
            entity.Surname = "Kekov";
            entity.Age = 18;
            entity.ContactNumber = "+375 (29) 123-45-67";
            entity.Email = "example123@mail.ru";
            entity.AllowEmailNotification = false;

            return entity;
        }

        [Fact]
        public async Task GetClientByIdReturnsNotFound()
        {
            var clientId = Guid.NewGuid();

            var uri = new Uri($"api/v1/clients/{clientId}", UriKind.Relative);
            var response = await Client.GetAsync(uri).ConfigureAwait(false);
            
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var apiEntity = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);

            apiEntity.Should().NotBeNull();
            apiEntity.Message.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateClientAndReturnsCreated()
        {
            var clientDomain = ConstructClient();
            
            await CreateClientAndValidateResponse(clientDomain);
        }

        [Fact]
        public async Task CreateClientAndThenGetById()
        {
            var clientDomain = ConstructClient();

            await CreateClientAndValidateResponse(clientDomain);

            await GetClientByTargetIdAndValidateResponse(clientDomain);
        }

        [Fact]
        public async Task CreateClientAndReturnsBadRequest()
        {
            var clientDomain = ConstructClient();

            var uri = new Uri($"api/v1/clients", UriKind.Relative);

            clientDomain.Age = -1;

            var body = JsonConvert.SerializeObject(clientDomain);

            using StringContent stringContent = new StringContent(body);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await Client.PostAsync(uri, stringContent).ConfigureAwait(false);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetAllClientsAndReturnsOk()
        {
            var uri = new Uri($"api/v1/clients", UriKind.Relative);

            using var response = await Client.GetAsync(uri).ConfigureAwait(false);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var apiEntities = JsonConvert.DeserializeObject<List<ClientResponseModel>>(responseContent);

            var clients = await Context.Set<Client>().ToListAsync();

            apiEntities.Should().NotBeEmpty();
            apiEntities.Count.Should().Be(clients.Count);
        }

        [Fact]
        public async Task DeleteClientByValidIdAndReturnsNoContent()
        {
            var clientDomain = ConstructClient();

            await CreateClientAndValidateResponse(clientDomain);

            var uri = new Uri($"api/v1/clients/{clientDomain.Id}", UriKind.Relative);

            using var response = await Client.DeleteAsync(uri).ConfigureAwait(false);

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            var client = await Context.Set<Client>().Where(c => c.Id.Equals(clientDomain.Id)).SingleOrDefaultAsync();

            client.Should().BeNull();
        }

        [Fact]
        public async Task DeleteClientByInvalidIdAndReturnsNotFound()
        {
            var clientDomain = ConstructClient();
            
            var uri = new Uri($"api/v1/clients/{clientDomain.Id}", UriKind.Relative);

            using var response = await Client.DeleteAsync(uri).ConfigureAwait(false);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var baseResponseModel = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);

            baseResponseModel.Should().NotBeNull();
            baseResponseModel.Message.Should().Be($"Client with id: {clientDomain.Id} doesn`t exist in the database.");
            baseResponseModel.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateClientAndReturnsOk()
        {
            var clientDomain = ConstructClient();

            await CreateClientAndValidateResponse(clientDomain);

            var uri = new Uri($"api/v1/clients/{clientDomain.Id}", UriKind.Relative);

            clientDomain.Age = 20;

            var body = JsonConvert.SerializeObject(clientDomain);

            using StringContent stringContent = new StringContent(body);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await Client.PutAsync(uri, stringContent).ConfigureAwait(false);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var apiEntity = JsonConvert.DeserializeObject<ClientResponseModel>(responseContent);

            apiEntity.Should().NotBeNull();
            apiEntity.FullName.Should().Be($"{clientDomain.Name} {clientDomain.Surname}");
            apiEntity.Age.Should().Be(clientDomain.Age);
            apiEntity.ContactNumber.Should().Be(clientDomain.ContactNumber);
            apiEntity.Email.Should().Be(clientDomain.Email);
            apiEntity.AllowEmailNotification.Should().Be(clientDomain.AllowEmailNotification);
        }
        
        [Fact]
        public async Task UpdateClientByInvalidIdAndReturnsNotFound()
        {
            var clientDomain = ConstructClient();

            var invalidId = Guid.NewGuid();

            var uri = new Uri($"api/v1/clients/{invalidId}", UriKind.Relative);

            var body = JsonConvert.SerializeObject(clientDomain);

            using StringContent stringContent = new StringContent(body);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await Client.PutAsync(uri, stringContent).ConfigureAwait(false);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var baseResponseModel = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);

            baseResponseModel.Message.Should().Be($"Client with id: {invalidId} doesn`t exist in the database.");
            baseResponseModel.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Fact]
        public async Task UpdateClientAndReturnsBadRequest()
        {
            var clientDomain = ConstructClient();

            var uri = new Uri($"api/v1/clients/{clientDomain.Id}", UriKind.Relative);

            clientDomain.Age = -1;

            var body = JsonConvert.SerializeObject(clientDomain);

            using StringContent stringContent = new StringContent(body);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await Client.PutAsync(uri, stringContent).ConfigureAwait(false);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        public async Task CreateClientAndValidateResponse(Client client)
        {
            var uri = new Uri($"api/v1/clients", UriKind.Relative);

            var body = JsonConvert.SerializeObject(client);

            using StringContent stringContent = new StringContent(body);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await Client.PostAsync(uri, stringContent).ConfigureAwait(false);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var apiEntity = JsonConvert.DeserializeObject<ClientResponseModel>(responseContent);

            CleanupActions.Add(() => Context.Remove(client));

            client.Id = apiEntity.Id;

            apiEntity.Should().NotBeNull();
            apiEntity.FullName.Should().Be($"{client.Name} {client.Surname}");
            apiEntity.Age.Should().Be(client.Age);
            apiEntity.ContactNumber.Should().Be(client.ContactNumber);
            apiEntity.Email.Should().Be(client.Email);
            apiEntity.AllowEmailNotification.Should().Be(client.AllowEmailNotification);
        }

        public async Task GetClientByTargetIdAndValidateResponse(Client client)
        {
            var uri = new Uri($"api/v1/clients/{client.Id}", UriKind.Relative);
            var response = await Client.GetAsync(uri).ConfigureAwait(false);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var apiEntity = JsonConvert.DeserializeObject<ClientResponseModel>(responseContent);

            apiEntity.Should().NotBeNull();
            apiEntity.FullName.Should().Be($"{client.Name} {client.Surname}");
            apiEntity.Age.Should().Be(client.Age);
            apiEntity.ContactNumber.Should().Be(client.ContactNumber);
            apiEntity.Email.Should().Be(client.Email);
            apiEntity.AllowEmailNotification.Should().Be(client.AllowEmailNotification);
        }
    }
}
