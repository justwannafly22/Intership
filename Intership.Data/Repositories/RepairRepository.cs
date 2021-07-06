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
        public RepairRepository(MyDbContext context)
            : base(context)
        {
        }
        
        /// <summary>
        /// Create a repair
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateAsync(RepairParameter model)
        {
            var repair = new Repair()
            {
                Name = model.Name
            };

            await CreateAsync(repair);

            return repair.Id;
        }

        /// <summary>
        /// Delete a repair
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var repair = await FindByCondition(r => r.Id.Equals(id), trackChanges: false)
                .SingleOrDefaultAsync();

            await DeleteAsync(repair);
        }

        /// <summary>
        /// Returns a repair
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Repair> GetAsync(Guid id) =>
            await FindByCondition(r => r.Id.Equals(id), trackChanges : true)
            .Include(r => r.RepairInfo)
                .ThenInclude(r => r.Status)
            .SingleOrDefaultAsync();
        
        /// <summary>
        /// Returns all repairs
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Repair>> GetAllAsync() =>
            await FindAll(trackChanges : false)
            .Include(r => r.RepairInfo)
                .ThenInclude(r => r.Status)
            .ToListAsync();
        
        /// <summary>
        /// Returns a repair
        /// </summary>
        /// <param name="repairId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Repair> GetWithReplacedParts(Guid repairId) =>
            await FindByCondition(r => r.Id.Equals(repairId), trackChanges : true)
            .Include(r => r.ReplacedParts)
            .SingleOrDefaultAsync();
        
        /// <summary>
        /// Update a repair
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, RepairParameter model)
        {
            var repair = await FindByCondition(r => r.Id.Equals(id), trackChanges: true)
                .SingleOrDefaultAsync();

            repair.Name = model.Name;

            await UpdateAsync(repair);

            return repair.Id;
        }
    }
}
