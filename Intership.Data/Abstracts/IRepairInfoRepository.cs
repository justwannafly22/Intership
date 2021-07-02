using Intership.Data.Entities;
using Intership.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    /// <summary>
    /// RepairInfo repository behavior
    /// </summary>
    public interface IRepairInfoRepository
    {
        Task<IEnumerable<RepairInfo>> GetRepairsInfoAsync(bool trackChanges);
        Task<RepairInfo> GetRepairInfoAsync(Guid id, bool trackChanges);
        Task<RepairInfo> GetRepairInfoAsync(Guid id, Guid repairId, bool trackChanges);
        Task<RepairInfo> GetRepairInfoByRepairIdAsync(Guid id, bool trackChanges);
        Task<Guid> CreateRepairInfoAsync(RepairInfoParameter model, Guid repairId);
        Task<Guid> UpdateRepairInfoAsync(Guid id, RepairInfoParameter model);
        Task DeleteRepairInfoAsync(Guid id);
    }
}
