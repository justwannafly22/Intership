using Intership.Data.Entities;
using Intership.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    public interface IReplacedPartRepository
    {
        Task<Guid> CreateAsync(ReplacedPartParameter model);
        Task<Guid> UpdateAsync(Guid id, ReplacedPartParameter model);
        Task<IEnumerable<ReplacedPart>> GetAllAsync();
        Task<ReplacedPart> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Guid>> CreateRangeAsync(IEnumerable<ReplacedPartParameter> models);
    }
}
