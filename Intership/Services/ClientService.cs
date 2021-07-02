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
    /// Service to manage clients
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
        public async Task<Guid> CreateClientAsync(AddClientModel model) //AddClientParamater;
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _clientRepository.CreateClientAsync(_mapper.Map<ClientParameter>(model));
        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteClientAsync(Guid id)
        {
            await _clientRepository.DeleteClientAsync(id);
        }

        /// <summary>
        /// Returns a single client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClientResponseModel> GetClientAsync(Guid id) =>
            _mapper.Map<ClientResponseModel>(await _clientRepository.GetClientAsync(id, trackChanges: true));

        /// <summary>
        /// Returns a list of clients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ClientResponseModel>> GetClientsAsync() =>
            _mapper.Map<IEnumerable<ClientResponseModel>>(await _clientRepository.GetClientsAsync(trackChanges: false));

        /// <summary>
        /// Check for existing client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _clientRepository.GetClientAsync(id, trackChanges: false) != null;

        /// <summary>
        /// Client update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateClientAsync(Guid id, UpdateClientModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _clientRepository.UpdateClientAsync(id, _mapper.Map<ClientParameter>(model));
        }

        /// <summary>
        /// Returns a repairs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RepairResponseModel>> GetRepairs(Guid id)
        {
            var client = await _clientRepository.GetRepairWithRepairsAsync(id);

            return _mapper.Map<IEnumerable<RepairResponseModel>>(client.Repairs);
        }
    }
}