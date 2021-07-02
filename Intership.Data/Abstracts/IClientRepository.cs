using Intership.Data.Entities;
using System;
using System.Collections.Generic;
using Intership.Data.Parameters;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync(bool trackChanges);
        Task<Client> GetClientAsync(Guid id, bool trackChanges);
        Task DeleteClientAsync(ClientParameter clientParamater);
        Task<Guid> CreateClientAsync(ClientParameter clientParamater);
        Task<Guid> UpdateClientAsync(ClientParameter clientParamater);
    }
}
