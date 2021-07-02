using Intership.Data.Entities;
using System;
using System.Collections.Generic;
using Intership.Data.Parameters;
using System.Threading.Tasks;
using Intership.Models.ResponseModels;

namespace Intership.Data.Abstracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync(bool trackChanges);
        Task<Client> GetClientAsync(Guid id, bool trackChanges);
        Task DeleteClientAsync(Guid id);
        Task<Guid> CreateClientAsync(ClientParameter clientParamater);
        Task<Guid> UpdateClientAsync(Guid id, ClientParameter model);
        Task<Client> GetRepairWithRepairsAsync(Guid id);
    }
}
