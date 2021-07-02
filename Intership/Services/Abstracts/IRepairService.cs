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
        Task<IEnumerable<RepairResponseModel>> GetRepairsAsync();
        Task<RepairResponseModel> GetRepairAsync(Guid repairId);
        Task<Guid> UpdateRepairAsync(Guid id, UpdateRepairModel model);
        Task<Guid> CreateRepairAsync(AddRepairModel model);
        Task DeleteRepairAsync(Guid id);
        Task<IEnumerable<ReplacedPartResponseModel>> GetReplacePartsForRepair(Guid repairId);
        Task<bool> IsExist(Guid id);
    }
}
