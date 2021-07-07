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
        private readonly IRepairInfoRepository _repairInfoRepository;
        private readonly IMapper _mapper;

        public RepairService(IRepairRepository repairRepository, IRepairInfoRepository repairInfoRepository, IMapper mapper)
        {
            _repairRepository = repairRepository;
            _repairInfoRepository = repairInfoRepository;
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
            _ = await _repairInfoRepository.CreateAsync(_mapper.Map<RepairInfoParameter>(model), addedRepairId);

            return addedRepairId;
        }

        /// <summary>
        /// Delete a repair
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)//fix
        {
            var repair = await _repairRepository.GetAsync(id);

            await _repairRepository.DeleteAsync(repair.Id);
            await _repairInfoRepository.DeleteAsync(repair.RepairInfoId);
        }

        /// <summary>
        /// Returns a repair
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<RepairResponseModel> GetAsync(Guid repairId) =>
            _mapper.Map<RepairResponseModel>(await _repairRepository.GetAsync(repairId));

        /// <summary>
        /// Returns a repairs
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RepairResponseModel>> GetAllAsync() =>
            _mapper.Map<IEnumerable<RepairResponseModel>>(await _repairRepository.GetAllAsync());

        /// <summary>
        /// Check for existing repair
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _repairRepository.GetAsync(id) != null;

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

            var repair = await _repairRepository.GetAsync(id);

            var updatedRepairId = await _repairRepository.UpdateAsync(repair.Id, _mapper.Map<RepairParameter>(model));
            _ = await _repairInfoRepository.UpdateAsync(repair.RepairInfoId, _mapper.Map<RepairInfoParameter>(model));

            return updatedRepairId;
        }

        /// <summary>
        /// Returns a repair with replaced parts
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ReplacedPartResponseModel>> GetAllReplacedParts(Guid repairId)
        {
            var repair = await _repairRepository.GetWithReplacedParts(repairId);

            return _mapper.Map<IEnumerable<ReplacedPartResponseModel>>(repair.ReplacedParts);
        }
    }
}
