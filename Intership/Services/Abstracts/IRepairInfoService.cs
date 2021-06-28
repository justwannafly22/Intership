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
        Task<RepairInfoResponseModel> GetRepairInfoAsync(Guid id);
        Task<RepairInfoResponseModel> GetRepairInfoAsync(Guid id, Guid repairId);
        Task<RepairInfoResponseModel> GetRepairInfoByRepairIdAsync(Guid id);
        Task<Guid> CreateRepairInfoAsync(AddRepairInfoModel model, Guid repairId);
        Task<Guid> UpdateRepairInfoAsync(UpdateRepairInfoModel model);
        Task DeleteRepairInfoAsync(AddRepairInfoModel model);
        Task<bool> IsExist(Guid id);
    }

}
