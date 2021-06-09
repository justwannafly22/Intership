using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Abstracts.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync(bool trackChanges);
        Task<Client> GetClientAsync(Guid id, bool trachChanges);
        void DeleteClientAsync(Client client);
        void CreateAsync(Client client);
    }
}
