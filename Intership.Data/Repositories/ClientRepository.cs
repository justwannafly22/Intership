using Intership.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intership.Data.Abstracts;
using Intership.Data.Parameters;

namespace Intership.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(MyDbContext context)
            :base(context)
        {
        }

        public async Task<Guid> CreateClientAsync(ClientParameter model)
        {
            var client = new Client()
            {
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                AllowEmailNotification = model.AllowEmailNotification
            };

            await CreateAsync(client);

            return client.Id;
        }

        public async Task DeleteClientAsync(ClientParameter model)
        {
            var client = new Client()
            {
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                AllowEmailNotification = model.AllowEmailNotification
            };

            await DeleteAsync(client);
        }

        public async Task<Client> GetClientAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Client>> GetClientsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task<Guid> UpdateClientAsync(ClientParameter model)
        {
            var client = new Client()
            {
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                AllowEmailNotification = model.AllowEmailNotification
            };

            await UpdateAsync(client);

            return client.Id;
        }
    }
}
