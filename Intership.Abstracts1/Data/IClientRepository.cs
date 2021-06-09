using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Abstracts.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync(bool trackChanges);
        Task<Client> GetClientAsync(Guid id, bool trackChanges);
        void DeleteClientAsync(Client client);
        void CreateClientAsync(Client client);
        void UpdateClientAsync(Client client);
        Task SaveChangesAsync();
    }
}
