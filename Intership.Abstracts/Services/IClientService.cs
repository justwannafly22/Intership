using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Abstracts.Services
{
    /// <summary>
    /// Clieng logic 
    /// </summary>
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(Guid id);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Client client);
        Task CreateClientAsync(Client client);
    }
}
