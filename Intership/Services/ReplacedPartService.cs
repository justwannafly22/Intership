using AutoMapper;
using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Models.RequestModels.ReplacedPart;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Services
{
    /// <summary>
    /// ReplacedPart logic implementation
    /// </summary>
    public class ReplacedPartService : IReplacedPartService
    {
        private readonly IReplacedPartRepository _replacedPartRepository;
        private readonly IMapper _mapper;

        public ReplacedPartService(IReplacedPartRepository replacedPartRepository, IMapper mapper)
        {
            _replacedPartRepository = replacedPartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a replaced parts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Guid>> CreateManyAsync(IEnumerable<AddReplacedPartModel> models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models));
            }

            var addedReplacedPartsId = await _replacedPartRepository.CreateRangeAsync(_mapper.Map<IEnumerable<ReplacedPartParameter>>(models));

            return addedReplacedPartsId;
        }

        /// <summary>
        /// Update a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, UpdateReplacedPartModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var updatedReplacedPartId = await _replacedPartRepository.UpdateAsync(id, _mapper.Map<ReplacedPartParameter>(model));

            return updatedReplacedPartId;
        }

        /// <summary>
        /// Returns a replaced parts
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ReplacedPartResponseModel>> GetAllAsync() =>
            _mapper.Map<IEnumerable<ReplacedPartResponseModel>>(await _replacedPartRepository.GetAllAsync());

        /// <summary>
        /// Returns a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReplacedPartResponseModel> GetAsync(Guid id) =>
            _mapper.Map<ReplacedPartResponseModel>(await _replacedPartRepository.GetAsync(id));

        /// <summary>
        /// Delete a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id) =>
            await _replacedPartRepository.DeleteAsync(id);

        /// <summary>
        /// Check for existing a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _replacedPartRepository.GetAsync(id) != null;
    }
}
