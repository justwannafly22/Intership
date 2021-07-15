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
        /// Create a status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<StatusResponseModel> CreateAsync(AddStatusModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var addedStatus = await _statusRepository.CreateAsync(_mapper.Map<StatusParameter>(model));

            return _mapper.Map<StatusResponseModel>(addedStatus);
        }

        /// <summary>
        /// Delete a status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _statusRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Returns a status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<StatusResponseModel> GetAsync(Guid id) =>
            _mapper.Map<StatusResponseModel>(await _statusRepository.GetAsync(id));

        /// <summary>
        /// Returns all statuses
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<List<StatusResponseModel>> GetAllAsync() =>
            _mapper.Map<List<StatusResponseModel>>(await _statusRepository.GetAllAsync());

        /// <summary>
        /// Check for existing status in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _statusRepository.GetAsync(id) != null;

        /// <summary>
        /// Update a status and returns id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, UpdateStatusModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _statusRepository.UpdateAsync(id, _mapper.Map<StatusParameter>(model));
        }
    }
}
