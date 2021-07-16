using Intership.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intership.Data.Abstracts;
using Intership.Data.Parameters;

namespace Intership.Data.Repositories
{
    /// <summary>
    /// Client repository implementation
    /// </summary>
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(MyDbContext context)
            :base(context)
        {
        }
        
        /// <summary>
        /// Create a client
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Client> CreateAsync(ClientParameter model)
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

            await CreateAsync(client).ConfigureAwait(false);

            return client;
        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var client = await FindByCondition(c => c.Id.Equals(id))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            await DeleteAsync(client).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Client> GetAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id))
            .SingleOrDefaultAsync().ConfigureAwait(false);

        /// <summary>
        /// Returns all clients
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<List<Client>> GetAllAsync() =>
            await FindAll()
            .ToListAsync().ConfigureAwait(false);

        /// <summary>
        /// Returns a client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Client> GetWithRepairsAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id))
            .Include(c => c.Repairs)
            .SingleOrDefaultAsync().ConfigureAwait(false);

        /// <summary>
        /// Update a client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, ClientParameter model)
        {
            var client = await FindByCondition(c => c.Id.Equals(id))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            client.Name = model.Name;
            client.Surname = model.Surname;
            client.Age = model.Age;
            client.ContactNumber = model.ContactNumber;
            client.Email = model.Email;
            client.AllowEmailNotification = model.AllowEmailNotification;

            await UpdateAsync(client).ConfigureAwait(false);

            return client.Id;
        }
    }
}
