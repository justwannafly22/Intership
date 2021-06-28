﻿using Intership.Models.RequestModels.Client;
using Intership.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Services.Abstracts
{
    /// <summary>
    /// Clieng logic behavior
    /// </summary>
    public interface IClientService
    {
        Task<IEnumerable<ClientResponseModel>> GetClientsAsync();
        Task<ClientResponseModel> GetClientAsync(Guid id);
        Task<Guid> UpdateClientAsync(UpdateClientModel model);
        Task DeleteClientAsync(AddClientModel model);
        Task<Guid> CreateClientAsync(AddClientModel climodelent);
        Task<bool> IsExist(Guid id);
    }
}