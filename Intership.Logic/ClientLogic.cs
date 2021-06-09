using Entities.Models;
using Intership.Abstracts.Logic;
using Intership.Abstracts.Repositories;
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
            _clientRepository.CreateClientAsync(client);

            await _clientRepository.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(Client client)
        {
            _clientRepository.DeleteClientAsync(client);

            await _clientRepository.SaveChangesAsync();
        }

        public async Task<Client> GetCLientAsync(Guid id)
        {
            var clientEntity = await _clientRepository.GetClientAsync(id, trackChanges: false);

            return clientEntity;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var clientsEntity = await _clientRepository.GetClientsAsync(trackChanges: false);

            return clientsEntity;
        }

        public async Task UpdateClientAsync(Guid id, Client client)
        {
            _clientRepository.UpdateClientAsync(client);

            await _clientRepository.SaveChangesAsync();
        }
    }
}
