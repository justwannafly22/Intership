using Intership.Data.Abstracts;
using Intership.Data.Entities;
using Intership.Data.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    /// <summary>
    /// Status repository implementation
    /// </summary>
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository (MyDbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Create a status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Status> CreateAsync(StatusParameter model)
        {
            var status = new Status()
            {
                StatusInfo = model.StatusInfo
            };

            await CreateAsync(status).ConfigureAwait(false);

            return status;
        }

        /// <summary>
        /// Delete a status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var status = await FindByCondition(s => s.Id.Equals(id))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            await DeleteAsync(status).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Returns a status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Status> GetAsync(Guid id) =>
            await FindByCondition(s => s.Id.Equals(id))
            .SingleOrDefaultAsync().ConfigureAwait(false);

        /// <summary>
        /// Returns all statuses
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Status>> GetAllAsync() =>
            await FindAll()
            .ToListAsync().ConfigureAwait(false);

        /// <summary>
        /// Update a status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, StatusParameter model)
        {
            var status = await FindByCondition(s => s.Id.Equals(id))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            status.StatusInfo = model.StatusInfo;

            await UpdateAsync(status).ConfigureAwait(false);

            return status.Id;
        }
    }
}
