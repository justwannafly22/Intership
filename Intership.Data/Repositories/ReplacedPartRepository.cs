using Intership.Data.Abstracts;
using Intership.Data.Entities;
using Intership.Data.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    public class ReplacedPartRepository : RepositoryBase<ReplacedPart>, IReplacedPartRepository
    {
        public ReplacedPartRepository(MyDbContext context)
            : base(context)
        {
        }

        public async Task<Guid> CreateReplacedPartAsync(ReplacedPartParameter model)
        {
            var replacedPart = new ReplacedPart()
            {
                Name = model.Name,
                Price = model.Price,
                Count = model.Count,
                AdvancedInfo = model.AdvancedInfo,
                RepairId = model.RepairId,
                ProductId = model.ProductId
            };

            await CreateAsync(replacedPart);

            return replacedPart.Id;
        }
        
        public async Task<Guid> UpdateReplacedPartAsync(Guid id, ReplacedPartParameter model)
        {
            var replacedPart = await FindByCondition(r => r.Id.Equals(id), trackChanges: true)
                .SingleOrDefaultAsync();

            replacedPart.Name = model.Name;
            replacedPart.Price = model.Price;
            replacedPart.Count = model.Count;
            replacedPart.AdvancedInfo = model.AdvancedInfo;

            await UpdateAsync(replacedPart);

            return replacedPart.Id;
        }

        public async Task<IEnumerable<ReplacedPart>> GetReplacedPartsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();
        
        public async Task<ReplacedPart> GetReplacedPartAsync(Guid id, bool trackChanges) =>
            await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task DeleteReplacedPartAsync(Guid id) =>
            await DeleteAsync(await FindByCondition(r => r.Id.Equals(id), trackChanges: false).SingleOrDefaultAsync());
    }
}
