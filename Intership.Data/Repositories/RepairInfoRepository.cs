using Intership.Data.Abstracts;
using Intership.Data.Entities;
using Intership.Data.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    public class RepairInfoRepository : RepositoryBase<RepairInfo>, IRepairInfoRepository
    {
        public RepairInfoRepository(MyDbContext context)
            : base(context)
        {
        }

        public async Task<Guid> CreateRepairInfoAsync(RepairInfoParameter model, Guid repairId)
        {
            var repairInfo = new RepairInfo()
            {
                Date = model.Date,
                AdvancedInfo = model.AdvancedInfo,
                RepairId = repairId
            };

            await CreateAsync(repairInfo);

            return repairInfo.Id;
        }

        public async Task DeleteRepairInfoAsync(RepairInfoParameter model)
        {
            var repairInfo = new RepairInfo()
            {
                Date = model.Date,
                AdvancedInfo = model.AdvancedInfo
            };

            await DeleteAsync(repairInfo);
        }

        public async Task<RepairInfo> GetRepairInfoAsync(Guid id, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<RepairInfo> GetRepairInfoAsync(Guid id, Guid repairId, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id) && r.RepairId.Equals(repairId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<RepairInfo> GetRepairInfoByRepairIdAsync(Guid repairId, bool trackChanges) =>
            await FindByCondition(r => r.RepairId.Equals(repairId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<RepairInfo>> GetRepairsInfoAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();
        
        public async Task<Guid> UpdateRepairInfoAsync(RepairInfoParameter model)
        {
            var repairInfo = new RepairInfo()
            {
                Date = model.Date,
                AdvancedInfo = model.AdvancedInfo
            };

            await UpdateAsync(repairInfo);

            return repairInfo.Id;
        }
    }
}
