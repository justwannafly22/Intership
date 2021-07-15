using Intership.Data.Entities;
using Intership.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    public interface IReplacedPartRepository
    {
        Task<ReplacedPart> CreateAsync(ReplacedPartParameter model);
        Task<Guid> UpdateAsync(Guid id, ReplacedPartParameter model);
        Task<List<ReplacedPart>> GetAllAsync();
        Task<ReplacedPart> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<List<Guid>> CreateRangeAsync(List<ReplacedPartParameter> models);
    }
}
