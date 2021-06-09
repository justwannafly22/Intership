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
        private readonly MyDbContext _context;

        public ClientRepository(MyDbContext context)
            : base(context)
        {
            _context = context;
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

        public void UpdateClientAsync(Client client) =>
            Update(client);

        public Task SaveChangesAsync() =>
            _context.SaveChangesAsync();
    }
}
