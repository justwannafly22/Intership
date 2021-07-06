using AutoMapper;
using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Models.RequestModels.Repair;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Services
{
    /// <summary>
    /// Repair logic implementation
    /// </summary>
    public class RepairService : IRepairService
    {
        private readonly IRepairRepository _repairRepository;
        private readonly IMapper _mapper;

        public RepairService(IRepairRepository repairRepository, IMapper mapper)
        {
            _repairRepository = repairRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a repair
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateAsync(AddRepairModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var addedRepairId = await _repairRepository.CreateAsync(_mapper.Map<RepairParameter>(model));
            
            return addedRepairId;
        }

        /// <summary>
        /// Delete a repair
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _repairRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Returns a repair
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<RepairResponseModel> GetAsync(Guid repairId) =>
            _mapper.Map<RepairResponseModel>(await _repairRepository.GetAsync(repairId, trackChanges: true));

        /// <summary>
        /// Returns a repairs
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RepairResponseModel>> GetAllAsync() =>
            _mapper.Map<IEnumerable<RepairResponseModel>>(await _repairRepository.GetAllAsync(trackChanges: false));

        /// <summary>
        /// Check for existing repair
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _repairRepository.GetAsync(id, trackChanges: false) != null;

        /// <summary>
        /// Update a repair
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, UpdateRepairModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _repairRepository.UpdateAsync(id, _mapper.Map<RepairParameter>(model));
        }

        /// <summary>
        /// Returns a repair with replaced parts
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ReplacedPartResponseModel>> GetAllForRepair(Guid repairId)
        {
            var repair = await _repairRepository.GetWithReplacedParts(repairId, trackChanges: false);

            return _mapper.Map<IEnumerable<ReplacedPartResponseModel>>(repair.ReplacedParts);
        }
    }
}
