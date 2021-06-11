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
        Task CreateRepairInfoAsync(RepairInfo repairInfo);
        Task UpdateRepairInfoAsync(RepairInfo repairInfo);
        Task DeleteRepairInfoAsync(RepairInfo repairInfo);
    }
}
