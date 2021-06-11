using Intership.Abstracts.Repositories;
using Intership.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Data
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context)
            : base(context)
        {
        }

        public async Task CreateProductAsync(Product product) =>
            await CreateAsync(product);

        public async Task DeleteProductAsync(Product product) =>
            await DeleteAsync(product);

        public async Task<Product> GetProductAsync(Guid id, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task UpdateProductAsync(Product product) =>
            await UpdateProductAsync(product);
    }
}
