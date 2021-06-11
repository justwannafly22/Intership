using Intership.Abstracts.Repositories;
using Intership.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Intership.Data
{
    public class RepairInfoRepository : RepositoryBase<RepairInfo>, IRepairInfoRepository
    {
        public RepairInfoRepository(MyDbContext context)
            : base(context)
        {
        }

        public async Task CreateRepairInfo(RepairInfo repairInfo) =>
            await CreateAsync(repairInfo);

        public async Task DeleteRepairInfo(RepairInfo repairInfo) =>
            await DeleteAsync(repairInfo);

        public async Task<RepairInfo> GetRepairInfoAsync(Guid id, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task UpdateRepairInfo(RepairInfo repairInfo) =>
            await UpdateAsync(repairInfo);
    }
}
