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
    /// RepairInfo logic implementation
    /// </summary>
    public class RepairInfoService : IRepairInfoService
    {
        private readonly IRepairInfoRepository _repairInfoRepository;

        public RepairInfoService(IRepairInfoRepository repairInfoRepository)
        {
            _repairInfoRepository = repairInfoRepository;
        }

        public async Task CreateRepairInfoAsync(Guid repairId, RepairInfo repairInfo)
        {
            repairInfo.RepairId = repairId;

            await _repairInfoRepository.CreateRepairInfoAsync(repairInfo);
        }

        public async Task DeleteRepairInfoAsync(RepairInfo repairInfo)
        {
            await _repairInfoRepository.DeleteRepairInfoAsync(repairInfo);
        }

        public async Task<RepairInfo> GetRepairInfoAsync(Guid repairId)
        {
            var repairInfo = await _repairInfoRepository.GetRepairInfoAsync(repairId, trackChanges: false);

            return repairInfo;
        }

        public async Task UpdateRepairInfoAsync(RepairInfo repairInfo)
        {
            await _repairInfoRepository.UpdateRepairInfoAsync(repairInfo);
        }
    }
}
