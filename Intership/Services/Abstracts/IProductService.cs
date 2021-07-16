﻿using Intership.Models.RequestModels.Product;
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
        Task<List<RepairResponseModel>> GetRepairsByProductAsync(Guid productId);
        Task<RepairResponseModel> GetRepairByProductAsync(Guid productId, Guid repairId);
        Task<List<ProductResponseModel>> GetAllAsync();
        Task<ProductResponseModel> GetAsync(Guid id);
        Task<ProductResponseModel> CreateAsync(AddProductModel model);
        Task<Guid> UpdateAsync(Guid id, UpdateProductModel model);
        Task DeleteAsync(Guid id);
        Task<bool> IsRepairExist(Guid productId, Guid repairsIds);
        Task<bool> IsExist(Guid id);
    }
}
