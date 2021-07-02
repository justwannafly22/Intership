using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context)
            : base(context)
        {
        }

        public async Task<Guid> CreateProductAsync(ProductParameter model)
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

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await FindByCondition(p => p.Id.Equals(id), trackChanges: false)
                .SingleOrDefaultAsync();

            await DeleteAsync(product);
        }

        public async Task<Product> GetProductAsync(Guid id, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task<Guid> UpdateProductAsync(Guid id, ProductParameter model)
        {
            var product = await FindByCondition(p => p.Id.Equals(id), trackChanges: true).
                SingleOrDefaultAsync();

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;

            await UpdateAsync(product);

            return product.Id;
        }

        public async Task<Product> GetProductWithRepairsAsync(Guid id, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges)
            .Include(p => p.ReplacedParts)
                .ThenInclude(r => r.Repair)
                    .ThenInclude(r => r.RepairInfo)
                        .ThenInclude(r => r.Status)
            .SingleOrDefaultAsync();

        public async Task SaveChangesAsync() =>
            await Save();
    }
}
