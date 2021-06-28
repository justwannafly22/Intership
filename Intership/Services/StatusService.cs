using AutoMapper;
using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Models.RequestModels.Status;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Services
{
    /// <summary>
    /// Status logic implementation
    /// </summary>
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusService (IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a status and returns id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateStatusAsync(AddStatusModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _statusRepository.CreateStatusAsync(_mapper.Map<StatusParameter>(model));
        }

        /// <summary>
        /// Delete a status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteStatusAsync(AddStatusModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _statusRepository.DeleteStatusAsync(_mapper.Map<StatusParameter>(model));
        }

        /// <summary>
        /// Returns a status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<StatusResponseModel> GetStatusAsync(Guid id) =>
            _mapper.Map<StatusResponseModel>(await _statusRepository.GetStatusAsync(id, trackChanges: true));

        /// <summary>
        /// Returns all statuses
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StatusResponseModel>> GetStatusesAsync() =>
            _mapper.Map<IEnumerable<StatusResponseModel>>(await _statusRepository.GetStatusesAsync(trackChanges: false));

        /// <summary>
        /// Check for existing status in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _statusRepository.GetStatusAsync(id, trackChanges: false) != null;

        /// <summary>
        /// Update a status and returns id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateStatusAsync(UpdateStatusModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _statusRepository.UpdateStatusAsync(_mapper.Map<StatusParameter>(model));
        }
    }
}
