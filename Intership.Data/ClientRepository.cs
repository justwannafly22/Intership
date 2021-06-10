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

        public void CreateClientAsync(Client client) =>
            Create(client);

        public void DeleteClientAsync(Client client) =>
            Delete(client);

        public async Task<Client> GetClientAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Client>> GetClientsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task SaveChangesAsync() =>
            await SaveChangesAsync();
    }
}
