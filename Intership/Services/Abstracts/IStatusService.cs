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
        Task<IEnumerable<StatusResponseModel>> GetStatusesAsync();
        Task<StatusResponseModel> GetStatusAsync(Guid id);
        Task<Guid> UpdateStatusAsync(UpdateStatusModel model);
        Task<Guid> CreateStatusAsync(AddStatusModel model);
        Task DeleteStatusAsync(AddStatusModel model);
        Task<bool> IsExist(Guid id);
    }
}
