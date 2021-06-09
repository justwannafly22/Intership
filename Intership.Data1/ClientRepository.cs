using Entities.Models;
using Intership.Abstracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(MyDbContext context)
            : base(context)
        {
        }

        public void CreateAsync(Client client) =>
            Create(client);

        public void DeleteClientAsync(Client client) =>
            Delete(client);

        public async Task<Client> GetClientAsync(Guid id, bool trachChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trachChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Client>> GetClientsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();
    }
}
