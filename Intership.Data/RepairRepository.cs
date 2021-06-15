using Intership.Abstracts.Repositories;
using Intership.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Data
{
    public class RepairRepository : RepositoryBase<Repair>, IRepairRepository
    {
        /// <summary>
        /// Repair repository implementation
        /// </summary>
        /// <param name="context"></param>
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
            .Include(r => r.RepairInfo)
            .ThenInclude(r => r.Status)
            .Include(r => r.ReplacedParts)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Repair>> GetRepairsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(r => r.RepairInfo)
            .ThenInclude(r => r.Status)
            .Include(r => r.ReplacedParts)
            .ToListAsync();

        public async Task UpdateRepairAsync(Repair repair) =>
            await UpdateAsync(repair);
    }
}
