using Intership.Abstracts.Repositories;
using Intership.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Data
{
    public class RepairRepository : RepositoryBase<Repair>, IRepairRepository
    {
        public RepairRepository(MyDbContext context)
            : base(context)
        {
        }

        public async Task CreateRepairAsync(Repair repair) =>
            await CreateAsync(repair);

        public async Task DeleteRepairAsync(Repair repair) =>
            await DeleteAsync(repair);

        public async Task<Repair> GetRepairAsync(Guid id, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Repair>> GetRepairsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task UpdateRepairAsync(Repair repair) =>
            await UpdateAsync(repair);
    }
}
