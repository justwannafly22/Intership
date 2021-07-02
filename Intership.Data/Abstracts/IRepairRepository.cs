using Intership.Data.Parameters;
using Intership.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    /// <summary>
    /// Repair repository behavior
    /// </summary>
    public interface IRepairRepository
    {
        Task<IEnumerable<Repair>> GetRepairsAsync(bool trackChanges);
        Task<Repair> GetRepairAsync(Guid id, bool trackChanges);
        Task<Guid> CreateRepairAsync(RepairParameter model);
        Task<Guid> UpdateRepairAsync(RepairParameter model);
        Task DeleteRepairAsync(RepairParameter model);
    }
}
