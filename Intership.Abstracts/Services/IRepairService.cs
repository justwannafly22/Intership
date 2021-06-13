using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Abstracts.Services
{
    /// <summary>
    /// Repair logic behavior
    /// </summary>
    public interface IRepairService
    {
        Task<IEnumerable<Repair>> GetRepairsAsync(Guid productId);
        Task<Repair> GetRepairAsync(Guid repairId, Guid productId);
        Task UpdateRepairAsync(Repair repair);
        Task CreateRepairAsync(Guid productId, Repair repair);
        Task DeleteRepairAsync(Repair repair);
    }
}
