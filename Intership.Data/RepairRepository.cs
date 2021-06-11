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

        public async Task<Repair> GetRepairAsync(Guid id, Guid productId, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id) && r.ProductId.Equals(productId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Repair>> GetRepairsAsync(Guid productId, bool trackChanges) =>
            await FindByCondition(r => r.Product.Equals(productId), trackChanges)
            .ToListAsync();

        public async Task UpdateRepairAsync(Repair repair) =>
            await UpdateAsync(repair);
    }
}
