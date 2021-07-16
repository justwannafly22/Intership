using Intership.Data.Abstracts;
using Moq;

namespace Intership.Tests.Mocks
{
    public class ClientFakeRepository
    {
        public Mock<IClientRepository> Mock;
        public IClientRepository Repository;

        public ClientFakeRepository()
        {
            Mock = new Mock<IClientRepository>();

            Repository = Mock.Object;
        }
    }
}
