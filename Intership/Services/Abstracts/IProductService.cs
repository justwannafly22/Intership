using Intership.Models.RequestModels.Product;
using Intership.Models.RequestModels.Repair;
using Intership.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Services.Abstracts
{
    /// <summary>
    /// Product logic behavior
    /// </summary>
    public interface IProductService
    {
        Task<IEnumerable<RepairResponseModel>> GetRepairsByProduct(Guid productId);
        Task<RepairResponseModel> GetRepairByProduct(Guid productId, Guid repairId);
        Task<IEnumerable<ProductResponseModel>> GetProductsAsync();
        Task<ProductResponseModel> GetProductAsync(Guid id);
        Task<Guid> CreateProductAsync(AddProductModel model);
        Task<Guid> UpdateProductAsync(UpdateProductModel model);
        Task DeleteProductAsync(AddProductModel model);
        Task<Guid> CreateRepairForProductAsync(AddRepairModel model, Guid productId);
        Task<Guid> UpdateRepairForProductAsync(UpdateRepairModel model, Guid productId, Guid repairId);
        Task DeleteRepairForProductAsync(Guid productId, Guid repairId);
        Task<bool> IsExist(Guid id);
    }
}
