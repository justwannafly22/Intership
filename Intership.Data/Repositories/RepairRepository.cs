using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    /// <summary>
    /// Repair repository implementation
    /// </summary>
    public class RepairRepository : RepositoryBase<Repair>, IRepairRepository
    {
        public RepairRepository(MyDbContextIdentity context)
            : base(context)
        {
        }
        
        /// <summary>
        /// Create a repair
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Repair> CreateAsync(RepairParameter model)
        {
            var repair = new Repair()
            {
                Name = model.Name
            };

            await CreateAsync(repair).ConfigureAwait(false);

            return repair;
        }

        /// <summary>
        /// Delete a repair
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var repair = await FindByCondition(r => r.Id.Equals(id))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            await DeleteAsync(repair).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a repair
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Repair> GetAsync(Guid id) =>
            await FindByCondition(r => r.Id.Equals(id))
            .Include(r => r.RepairInfo)
                .ThenInclude(r => r.Status)
            .SingleOrDefaultAsync().ConfigureAwait(false);

        /// <summary>
        /// Returns all repairs
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Repair>> GetAllAsync() =>
            await FindAll()
            .Include(r => r.RepairInfo)
                .ThenInclude(r => r.Status)
            .ToListAsync().ConfigureAwait(false);

        /// <summary>
        /// Returns a repair
        /// </summary>
        /// <param name="repairId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Repair> GetWithReplacedParts(Guid repairId) =>
            await FindByCondition(r => r.Id.Equals(repairId))
            .Include(r => r.ReplacedParts)
            .SingleOrDefaultAsync().ConfigureAwait(false);

        /// <summary>
        /// Update a repair
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, RepairParameter model)
        {
            var repair = await FindByCondition(r => r.Id.Equals(id))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            repair.Name = model.Name;

            await UpdateAsync(repair).ConfigureAwait(false);

            return repair.Id;
        }
    }
}
