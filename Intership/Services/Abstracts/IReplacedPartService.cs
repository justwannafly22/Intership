using Intership.Models.RequestModels.ReplacedPart;
using Intership.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Services.Abstracts
{
    public interface IReplacedPartService
    {
        Task<IEnumerable<Guid>> CreateReplacedPartsAsync(IEnumerable<AddReplacedPartModel> models);
        Task<Guid> UpdateReplacedPartAsync(Guid id, UpdateReplacedPartModel model);
        Task<IEnumerable<ReplacedPartResponseModel>> GetReplacedPartsAsync();
        Task<ReplacedPartResponseModel> GetReplacedPartAsync(Guid id);
        Task DeleteReplacedPartAsync(Guid id);
        Task<bool> IsExist(Guid id);
    }
}
