using Intership.Data.Entities;
using Intership.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllAsync();
        Task<Status> GetAsync(Guid id);
        Task<Guid> UpdateAsync(Guid id, StatusParameter model);
        Task<Guid> CreateAsync(StatusParameter model);
        Task DeleteAsync(Guid id);
    }
}
