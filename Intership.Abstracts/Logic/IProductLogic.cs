using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Abstracts.Logic
{
    public interface IProductLogic
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
    }
}
