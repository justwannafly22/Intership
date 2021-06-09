using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Abstracts.Logic
{
    public interface IClientLogic
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetCLientAsync(Guid id);
        Task CreateClientAsync(Client client);
        Task UpdateClientAsync(Guid id, Client client);
        Task DeleteClientAsync(Client client);
    }
}
