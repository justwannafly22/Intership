using Intership.Models.RequestModels.Client;
using Intership.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Services.Abstracts
{
    /// <summary>
    /// Clieng logic behavior
    /// </summary>
    public interface IClientService
    {
        Task<IEnumerable<ClientResponseModel>> GetClientsAsync();
        Task<ClientResponseModel> GetClientAsync(Guid id);
        Task<Guid> UpdateClientAsync(Guid id, UpdateClientModel model);
        Task DeleteClientAsync(Guid id);
        Task<Guid> CreateClientAsync(AddClientModel climodelent);
        Task<bool> IsExist(Guid id);
        Task<IEnumerable<RepairResponseModel>> GetRepairs(Guid id);
    }
}
