using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    /// <summary>
    /// Product repository implementation
    /// </summary>
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateAsync(ProductParameter model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };

            await CreateAsync(product);

            return product.Id;
        }
        
        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var product = await FindByCondition(p => p.Id.Equals(id), trackChanges: false)
                .SingleOrDefaultAsync();

            await DeleteAsync(product);
        }

        /// <summary>
        /// Returns a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Product> GetAsync(Guid id) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges : true)
            .SingleOrDefaultAsync();

        /// <summary>
        /// Returns a products
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await FindAll(trackChanges : false)
            .ToListAsync();

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, ProductParameter model)
        {
            var product = await FindByCondition(p => p.Id.Equals(id), trackChanges: true).
                SingleOrDefaultAsync();

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;

            await UpdateAsync(product);

            return product.Id;
        }

        /// <summary>
        /// Returns a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Product> GetWithRepairsAsync(Guid id) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges : false)
            .Include(p => p.ReplacedParts)
                .ThenInclude(r => r.Repair)
                    .ThenInclude(r => r.RepairInfo)
                        .ThenInclude(r => r.Status)
            .SingleOrDefaultAsync();
    }
}
