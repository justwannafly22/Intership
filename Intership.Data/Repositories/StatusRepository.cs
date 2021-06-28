using Intership.Data.Abstracts;
using Intership.Data.Entities;
using Intership.Data.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Data.Repositories
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository (MyDbContext context)
            : base(context)
        {
        }

        public async Task<Guid> CreateStatusAsync(StatusParameter model)
        {
            var status = new Status()
            {
                StatusInfo = model.StatusInfo
            };

            await CreateAsync(status);

            return status.Id;
        }

        public async Task DeleteStatusAsync(StatusParameter model)
        {
            var status = new Status()
            {
                StatusInfo = model.StatusInfo
            };

            await DeleteAsync(status);
        }

        public async Task<Status> GetStatusAsync(Guid id, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Status>> GetStatusesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task<Guid> UpdateStatusAsync(StatusParameter model)
        {
            var status = new Status()
            {
                StatusInfo = model.StatusInfo
            };

            await UpdateAsync(status);

            return status.Id;
        }
    }
}
