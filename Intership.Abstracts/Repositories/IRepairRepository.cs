using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Abstracts.Repositories
{
    /// <summary>
    /// Repair repository behavior
    /// </summary>
    public interface IRepairRepository
    {
        Task<IEnumerable<Repair>> GetRepairsAsync(bool trackChanges);
        Task<Repair> GetRepairAsync(Guid id, bool trackChanges);
        Task CreateRepairAsync(Repair repair);
        Task UpdateRepairAsync(Repair repair);
        Task DeleteRepairAsync(Repair repair);
    }
}
