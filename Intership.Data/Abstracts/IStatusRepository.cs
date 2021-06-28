using Intership.Data.Entities;
using Intership.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetStatusesAsync(bool trackChanges);
        Task<Status> GetStatusAsync(Guid id, bool trackChanges);
        Task<Guid> UpdateStatusAsync(StatusParameter model);
        Task<Guid> CreateStatusAsync(StatusParameter model);
        Task DeleteStatusAsync(StatusParameter model);
    }
}
