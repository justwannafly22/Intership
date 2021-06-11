using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Abstracts.Repositories
{
    public interface IRepairInfoRepository
    {
        Task<RepairInfo> GetRepairInfoAsync(Guid id, bool trackChanges);
        Task CreateRepairInfo(RepairInfo repairInfo);
        Task UpdateRepairInfo(RepairInfo repairInfo);
        Task DeleteRepairInfo(RepairInfo repairInfo);
    }
}
