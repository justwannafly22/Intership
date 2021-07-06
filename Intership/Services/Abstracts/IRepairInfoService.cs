using Intership.Models.RequestModels.RepairInfo;
using Intership.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Intership.Services.Abstracts
{
    /// <summary>
    /// RepairInfo logic behavior
    /// </summary>
    public interface IRepairInfoService
    {
        Task<RepairInfoResponseModel> GetAsync(Guid id);
        Task<RepairInfoResponseModel> GetAsync(Guid id, Guid repairId);
        Task<RepairInfoResponseModel> GetByRepairIdAsync(Guid id);
        Task<Guid> CreateAsync(AddRepairInfoModel model, Guid repairId);
        Task<Guid> UpdateAsync(Guid id, UpdateRepairInfoModel model);
        Task DeleteAsync(Guid id);
        Task<bool> IsExist(Guid id);
    }

}
