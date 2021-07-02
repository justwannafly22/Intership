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
                RepairId = repairId,
                StatusId = (Guid)model.StatusId
            };

            await CreateAsync(repairInfo);

            return repairInfo.Id;
        }

        public async Task DeleteRepairInfoAsync(Guid id)
        {
            var repairInfo = await FindByCondition(r => r.Id.Equals(id), trackChanges: false)
                .SingleOrDefaultAsync();

            await DeleteAsync(repairInfo);
        }

        public async Task<RepairInfo> GetRepairInfoAsync(Guid id, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .Include(r => r.Status)
            .SingleOrDefaultAsync();

        public async Task<RepairInfo> GetRepairInfoAsync(Guid id, Guid repairId, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id) && r.RepairId.Equals(repairId), trackChanges)
            .Include(r => r.Status)
            .SingleOrDefaultAsync();
            

        public async Task<RepairInfo> GetRepairInfoByRepairIdAsync(Guid repairId, bool trackChanges) =>
            await FindByCondition(r => r.RepairId.Equals(repairId), trackChanges)
            .Include(r => r.Status)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<RepairInfo>> GetRepairsInfoAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(r => r.Status)
            .ToListAsync();
        
        public async Task<Guid> UpdateRepairInfoAsync(Guid id, RepairInfoParameter model)
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
