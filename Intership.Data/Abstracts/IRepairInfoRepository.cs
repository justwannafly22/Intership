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
        Task<RepairInfo> GetAsync(Guid id, bool trackChanges);
        Task<RepairInfo> GetAsync(Guid id, Guid repairId, bool trackChanges);
        Task<RepairInfo> GetByRepairIdAsync(Guid id, bool trackChanges);
        Task<Guid> CreateAsync(RepairInfoParameter model, Guid repairId);
        Task<Guid> UpdateAsync(Guid id, RepairInfoParameter model);
        Task DeleteAsync(Guid id);
    }
}
