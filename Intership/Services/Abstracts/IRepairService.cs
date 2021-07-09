using Intership.Models.RequestModels.Repair;
using Intership.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Services.Abstracts
{
    /// <summary>
    /// Repair logic behavior
    /// </summary>
    public interface IRepairService
    {
        Task<List<RepairResponseModel>> GetAllAsync();
        Task<RepairResponseModel> GetAsync(Guid repairId);
        Task<Guid> UpdateAsync(Guid id, UpdateRepairModel model);
        Task<Guid> CreateAsync(AddRepairModel model);
        Task DeleteAsync(Guid id);
        Task<List<ReplacedPartResponseModel>> GetAllReplacedParts(Guid repairId);
        Task<bool> IsExist(Guid id);
    }
}
