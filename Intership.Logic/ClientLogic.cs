using Intership.Abstracts.Logic;
using Intership.Abstracts.Repositories;
using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Logic
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientRepository _clientRepository;

        public ClientLogic(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task CreateClientAsync(Client client)
        {
            await _clientRepository.CreateClientAsync(client);
        }

        public async Task DeleteClientAsync(Client client)
        {
            await _clientRepository.DeleteClientAsync(client);
        }

        public async Task<Client> GetClientAsync(Guid id)
        {
            var client = await _clientRepository.GetClientAsync(id, trackChanges: true);

            return client;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var clients = await _clientRepository.GetClientsAsync(trackChanges: false);

            return clients;
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _clientRepository.UpdateClientAsync(client);
        }
    }
}