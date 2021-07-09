using Intership.Models.RequestModels.Status;
using Intership.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Services.Abstracts
{
    /// <summary>
    /// Status logic behavior
    /// </summary>
    public interface IStatusService
    {
        Task<List<StatusResponseModel>> GetAllAsync();
        Task<StatusResponseModel> GetAsync(Guid id);
        Task<Guid> UpdateAsync(Guid id, UpdateStatusModel model);
        Task<Guid> CreateAsync(AddStatusModel model);
        Task DeleteAsync(Guid id);
        Task<bool> IsExist(Guid id);
    }
}
