using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    public class RepairRepository : RepositoryBase<Repair>, IRepairRepository
    {
        public RepairRepository(MyDbContext context)
            : base(context)
        {
        }

        public async Task<Guid> CreateRepairAsync(RepairParameter model)
        {
            var repair = new Repair()
            {
                Name = model.Name
            };

            await CreateAsync(repair);

            return repair.Id;
        }

        public async Task DeleteRepairAsync(Guid id)
        {
            var repair = await FindByCondition(r => r.Id.Equals(id), trackChanges: false)
                .SingleOrDefaultAsync();

            await DeleteAsync(repair);
        }

        public async Task<Repair> GetRepairAsync(Guid id, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .Include(r => r.RepairInfo)
                .ThenInclude(r => r.Status)
            .SingleOrDefaultAsync();
        
        public async Task<IEnumerable<Repair>> GetRepairsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(r => r.RepairInfo)
                .ThenInclude(r => r.Status)
            .ToListAsync();
        
        public async Task<Repair> GetRepairWithReplacedParts(Guid repairId, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(repairId), trackChanges)
            .Include(r => r.ReplacedParts)
            .SingleOrDefaultAsync();

        public async Task<Guid> UpdateRepairAsync(Guid id, RepairParameter model)
        {
            var repair = await FindByCondition(r => r.Id.Equals(id), trackChanges: true)
                .SingleOrDefaultAsync();

            repair.Name = model.Name;

            await UpdateAsync(repair);

            return repair.Id;
        }
    }
}
