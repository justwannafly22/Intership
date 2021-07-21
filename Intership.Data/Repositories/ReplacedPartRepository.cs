using Intership.Data.Abstracts;
using Intership.Data.Entities;
using Intership.Data.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    /// <summary>
    /// ReplacedPart repository implementation
    /// </summary>
    public class ReplacedPartRepository : RepositoryBase<ReplacedPart>, IReplacedPartRepository
    {
        public ReplacedPartRepository(MyDbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Create a replaced part
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ReplacedPart> CreateAsync(ReplacedPartParameter model)
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
            
            await CreateAsync(replacedPart).ConfigureAwait(false);

            return replacedPart;
        }
        
        /// <summary>
        /// Create many replaced parts
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<List<ReplacedPart>> CreateRangeAsync(List<ReplacedPartParameter> models)
        {
            var replacedParts = models.Select(r => new ReplacedPart()
            {
                Name = r.Name,
                Price = r.Price,
                Count = r.Count,
                AdvancedInfo = r.AdvancedInfo
            });

            await CreateRangeAsync(replacedParts).ConfigureAwait(false);

            return replacedParts.ToList();
        }

        /// <summary>
        /// Update a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, ReplacedPartParameter model)
        {
            var replacedPart = await FindByCondition(r => r.Id.Equals(id))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            replacedPart.Name = model.Name;
            replacedPart.Price = model.Price;
            replacedPart.Count = model.Count;
            replacedPart.AdvancedInfo = model.AdvancedInfo;

            await UpdateAsync(replacedPart).ConfigureAwait(false);

            return replacedPart.Id;
        }

        /// <summary>
        /// Returns all replaced parts
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<List<ReplacedPart>> GetAllAsync() =>
            await FindAll()
            .ToListAsync().ConfigureAwait(false);

        /// <summary>
        /// Returns a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<ReplacedPart> GetAsync(Guid id) =>
            await FindByCondition(r => r.Id.Equals(id))
            .SingleOrDefaultAsync().ConfigureAwait(false);

        /// <summary>
        /// Delete a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id) =>
            await DeleteAsync(await FindByCondition(r => r.Id.Equals(id)).SingleOrDefaultAsync()).ConfigureAwait(false);
    }
}
