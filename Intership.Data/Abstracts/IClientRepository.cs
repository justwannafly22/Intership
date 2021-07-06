using Intership.Data.Entities;
using System;
using System.Collections.Generic;
using Intership.Data.Parameters;
using System.Threading.Tasks;

namespace Intership.Data.Abstracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync(bool trackChanges);
        Task<Client> GetAsync(Guid id, bool trackChanges);
        Task DeleteAsync(Guid id);
        Task<Guid> CreateAsync(ClientParameter clientParamater);
        Task<Guid> UpdateAsync(Guid id, ClientParameter clientParamater);
        Task<Client> GetRepairWithRepairsAsync(Guid id);
    }
}
