using Intership.Abstracts.Repositories;
using Intership.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Intership.Data
{
    public class RepairInfoRepository : RepositoryBase<RepairInfo>, IRepairInfoRepository
    {
        /// <summary>
        /// RepairInfo repository implementation
        /// </summary>
        /// <param name="context"></param>
        public RepairInfoRepository(MyDbContext context)
            : base(context)
        {
        }

        public async Task CreateRepairInfoAsync(RepairInfo repairInfo)
        {
            await CreateAsync(repairInfo);
        }

        public async Task DeleteRepairInfoAsync(RepairInfo repairInfo) =>
            await DeleteAsync(repairInfo);

        public async Task<RepairInfo> GetRepairInfoAsync(Guid id, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
        
        public async Task UpdateRepairInfoAsync(RepairInfo repairInfo) =>
            await UpdateAsync(repairInfo);
    }
}
