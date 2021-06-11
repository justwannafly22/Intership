using Intership.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Intership.Abstracts.Services
{
    /// <summary>
    /// RepairInfo logic behavior
    /// </summary>
    public interface IRepairInfoService
    {
        Task<RepairInfo> GetRepairInfoAsync(Guid repairId);
        Task CreateRepairInfoAsync(Guid repairId, RepairInfo repairInfo);
        Task UpdateRepairInfoAsync(RepairInfo repairInfo);
        Task DeleteRepairInfoAsync(RepairInfo repairInfo);
    }
}
