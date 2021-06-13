using Intership.Abstracts.Repositories;
using Intership.Abstracts.Services;
using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Logic
{
    /// <summary>
    /// Repair logic implementation
    /// </summary>
    public class RepairService : IRepairService
    {
        private readonly IRepairRepository _repairRepository;

        public RepairService(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }
        
        public async Task CreateRepairAsync(Guid productId, Repair repair)
        {
            repair.ProductId = productId;

            await _repairRepository.CreateRepairAsync(repair);
        }

        public async Task DeleteRepairAsync(Repair repair)
        {
            await _repairRepository.DeleteRepairAsync(repair);
        }

        public async Task<Repair> GetRepairAsync(Guid repairId, Guid productId)
        {
            var repair = await _repairRepository.GetRepairAsync(repairId, productId, trackChanges: true);

            return repair;
        }

        public async Task<IEnumerable<Repair>> GetRepairsAsync(Guid productId)
        {
            var repairs = await _repairRepository.GetRepairsAsync(productId, trackChanges: false);

            return repairs;
        }

        public async Task UpdateRepairAsync(Repair repair)
        {
            await _repairRepository.UpdateRepairAsync(repair);
        }
    }
}
