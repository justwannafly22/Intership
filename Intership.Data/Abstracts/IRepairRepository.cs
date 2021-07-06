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
        Task<IEnumerable<Repair>> GetAllAsync();
        Task<Repair> GetAsync(Guid id);
        Task<Guid> CreateAsync(RepairParameter model);
        Task<Guid> UpdateAsync(Guid id, RepairParameter model);
        Task DeleteAsync(Guid id);
        Task<Repair> GetWithReplacedParts(Guid repairId);
    }
}
