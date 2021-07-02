using Intership.Data.Entities;
using Intership.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    public interface IReplacedPartRepository
    {
        Task<Guid> CreateReplacedPartAsync(ReplacedPartParameter model);
        Task<Guid> UpdateReplacedPartAsync(Guid id, ReplacedPartParameter model);
        Task<IEnumerable<ReplacedPart>> GetReplacedPartsAsync(bool trackChanges);
        Task<ReplacedPart> GetReplacedPartAsync(Guid id, bool trackChanges);
        Task DeleteReplacedPartAsync(Guid id);
    }
}
