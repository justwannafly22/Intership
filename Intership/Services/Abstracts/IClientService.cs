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
        Task<List<ClientResponseModel>> GetAllAsync();
        Task<ClientResponseModel> GetAsync(Guid id);
        Task<Guid> UpdateAsync(Guid id, UpdateClientModel model);
        Task DeleteAsync(Guid id);
        Task<ClientResponseModel> CreateAsync(AddClientModel climodelent);
        Task<bool> IsExist(Guid id);
        Task<List<RepairResponseModel>> GetRepairsAsync(Guid id);
    }
}
