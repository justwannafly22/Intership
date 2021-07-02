using Intership.Data.Parameters;
using Intership.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(bool trackChanges);
        Task<Product> GetProductAsync(Guid id, bool trackChanges);
        Task<Guid> CreateProductAsync(ProductParameter model);
        Task<Guid> UpdateProductAsync(Guid id, ProductParameter model);
        Task DeleteProductAsync(Guid id);
    }
}
