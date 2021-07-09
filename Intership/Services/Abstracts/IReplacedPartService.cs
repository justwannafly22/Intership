using Intership.Models.RequestModels.ReplacedPart;
using Intership.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Services.Abstracts
{
    public interface IReplacedPartService
    {
        Task<List<Guid>> CreateManyAsync(List<AddReplacedPartModel> models);
        Task<Guid> UpdateAsync(Guid id, UpdateReplacedPartModel model);
        Task<List<ReplacedPartResponseModel>> GetAllAsync();
        Task<ReplacedPartResponseModel> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<bool> IsExist(Guid id);
    }
}
