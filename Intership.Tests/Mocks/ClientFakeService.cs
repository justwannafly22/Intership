using Intership.Services.Abstracts;
using Moq;
using System;

namespace Intership.Tests.Mocks
{
    public class ClientFakeService
    {
        public Mock<IClientService> Mock;
        public IClientService Service;

        public ClientFakeService()
        {
            Mock = new Mock<IClientService>();
            Service = Mock.Object;
        }
    }
}
