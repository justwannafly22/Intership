using Intership.Data.Abstracts;
using Intership.Data.Entities;
using Intership.Data.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    /// <summary>
    /// RepairInfo repository implementation
    /// </summary>
    public class RepairInfoRepository : RepositoryBase<RepairInfo>, IRepairInfoRepository
    {
        public RepairInfoRepository(MyDbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Create a repair info
        /// </summary>
        /// <param name="model"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<Guid> CreateAsync(RepairInfoParameter model, Guid repairId)
        {
            var repairInfo = new RepairInfo()
            {
                Date = model.Date,
                AdvancedInfo = model.AdvancedInfo,
                RepairId = repairId,
                StatusId = (Guid)model.StatusId
            };

            await CreateAsync(repairInfo);

            return repairInfo.Id;
        }

        /// <summary>
        /// Delete a repair info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var repairInfo = await FindByCondition(r => r.Id.Equals(id), trackChanges: false)
                .SingleOrDefaultAsync();

            await DeleteAsync(repairInfo);
        }

        /// <summary>
        /// Returns a repair info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<RepairInfo> GetAsync(Guid id) =>
            await FindByCondition(r => r.Id.Equals(id), trackChanges : true)
            .Include(r => r.Status)
            .SingleOrDefaultAsync();
        
        /// <summary>
        /// Update a repair info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, RepairInfoParameter model)
        {
            var repairInfo = await FindByCondition(r => r.Id.Equals(id), trackChanges: false)
                .SingleOrDefaultAsync();

            repairInfo.Date = model.Date;
            repairInfo.AdvancedInfo = model.AdvancedInfo;
            repairInfo.StatusId = model.StatusId;

            await UpdateAsync(repairInfo);

            return repairInfo.Id;
        }
    }
}
