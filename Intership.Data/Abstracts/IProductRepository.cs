using Intership.Data.Parameters;
using Intership.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(Guid id);
        Task<Product> CreateAsync(ProductParameter model);
        Task<Guid> UpdateAsync(Guid id, ProductParameter model);
        Task DeleteAsync(Guid id);
        Task<Product> GetWithRepairsAsync(Guid id);
    }
}
