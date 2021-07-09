using AutoMapper;
using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Models.RequestModels.Client;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Services
{
    /// <summary>
    /// Client logic implementation
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new client
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateAsync(AddClientModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _clientRepository.CreateAsync(_mapper.Map<ClientParameter>(model));
        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _clientRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Returns a single client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClientResponseModel> GetAsync(Guid id) =>
            _mapper.Map<ClientResponseModel>(await _clientRepository.GetAsync(id));

        /// <summary>
        /// Returns a list of clients
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClientResponseModel>> GetAllAsync() =>
            _mapper.Map<List<ClientResponseModel>>(await _clientRepository.GetAllAsync());

        /// <summary>
        /// Check for existing client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _clientRepository.GetAsync(id) != null;

        /// <summary>
        /// Client update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, UpdateClientModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _clientRepository.UpdateAsync(id, _mapper.Map<ClientParameter>(model));
        }

        /// <summary>
        /// Returns a repairs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<RepairResponseModel>> GetRepairs(Guid id)
        {
            var client = await _clientRepository.GetWithRepairsAsync(id);

            return _mapper.Map<List<RepairResponseModel>>(client.Repairs);
        }
    }
}