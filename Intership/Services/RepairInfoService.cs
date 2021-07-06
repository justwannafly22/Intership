using AutoMapper;
using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Models.RequestModels.RepairInfo;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using System;
using System.Threading.Tasks;

namespace Intership.Services
{
    /// <summary>
    /// RepairInfo logic implementation
    /// </summary>
    public class RepairInfoService : IRepairInfoService
    {
        private readonly IRepairInfoRepository _repairInfoRepository;
        private readonly IMapper _mapper;

        public RepairInfoService(IRepairInfoRepository repairInfoRepository, IMapper mapper)
        {
            _repairInfoRepository = repairInfoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a repair info for the repair
        /// </summary>
        /// <param name="model"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<Guid> CreateAsync(AddRepairInfoModel model, Guid repairId)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _repairInfoRepository.CreateAsync(_mapper.Map<RepairInfoParameter>(model), repairId);
        }

        /// <summary>
        /// Delete a repair info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _repairInfoRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Returns a repair info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RepairInfoResponseModel> GetAsync(Guid id) =>
            _mapper.Map<RepairInfoResponseModel>(await _repairInfoRepository.GetAsync(id, trackChanges: true));

        /// <summary>
        /// Returns a repair info by repair id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<RepairInfoResponseModel> GetAsync(Guid id, Guid repairId) =>
            _mapper.Map<RepairInfoResponseModel>(await _repairInfoRepository.GetAsync(id, repairId, trackChanges: true));

        /// <summary>
        /// Returns a repair info by repair id
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<RepairInfoResponseModel> GetByRepairIdAsync(Guid repairId) =>
            _mapper.Map<RepairInfoResponseModel>(await _repairInfoRepository.GetByRepairIdAsync(repairId, trackChanges: true));

        /// <summary>
        /// Check for existing repair info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _repairInfoRepository.GetAsync(id, trackChanges: false) != null;

        /// <summary>
        /// Update a RepairInfo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, UpdateRepairInfoModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _repairInfoRepository.UpdateAsync(id, _mapper.Map<RepairInfoParameter>(model));
        }
    }
}
