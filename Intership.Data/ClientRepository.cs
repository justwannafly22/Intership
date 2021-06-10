using Intership.Abstracts.Repositories;
using Intership.Models.Entities;
using Intership.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Intership.Data
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(MyDbContext context)
            :base(context)
        {
        }
        
        public async Task CreateClientAsync(Client client) =>
            await CreateAsync(client);

        public async Task DeleteClientAsync(Client client) =>
            await DeleteAsync(client);

        public async Task<Client> GetClientAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Client>> GetClientsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task UpdateClientAsync(Client client)
        {
            await UpdateAsync(client);
        }
    }
}
