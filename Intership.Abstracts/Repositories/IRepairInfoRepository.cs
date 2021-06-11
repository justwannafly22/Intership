using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Abstracts.Repositories
{
    /// <summary>
    /// RepairInfo repository behavior
    /// </summary>
    public interface IRepairInfoRepository
    {
        Task<RepairInfo> GetRepairInfoAsync(Guid id, bool trackChanges);
        Task CreateRepairInfo(Guid repairId, RepairInfo repairInfo);
        Task UpdateRepairInfo(RepairInfo repairInfo);
        Task DeleteRepairInfo(RepairInfo repairInfo);
    }
}
