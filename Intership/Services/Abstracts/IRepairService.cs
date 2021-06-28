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
        Task<IEnumerable<ProductResponseModel>> GetProductsByRepair(Guid repairId);
        Task<IEnumerable<RepairResponseModel>> GetRepairsAsync();
        Task<RepairResponseModel> GetRepairAsync(Guid repairId);
        Task<Guid> UpdateRepairAsync(UpdateRepairModel model);
        Task<Guid> CreateRepairAsync(AddRepairModel model);
        Task DeleteRepairAsync(AddRepairModel model);
        Task<bool> IsExist(Guid id);
    }
}
