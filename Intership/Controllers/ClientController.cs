using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Threading.Tasks;
using Intership.Filters;
using Intership.LoggerService.Abstracts;
using Intership.Services.Abstracts;
using Intership.Models.RequestModels.Client;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, ILoggerManager logger, IMapper mapper)
        {
            _clientService = clientService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all clients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientService.GetClientsAsync();

            return Ok(clients);
        }

        /// <summary>
        /// Returns a single client
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClient(Guid clientId)
        {
            if (!await _clientService.IsExist(clientId)) 
            {
                _logger.LogInfo($"Client with id: {clientId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(await _clientService.GetClientAsync(clientId));
        }

        /// <summary>
        /// Create a new client
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateClient([FromBody] AddClientModel model)
        {
            var addedClientId = await _clientService.CreateClientAsync(model);

            return Created($"api/v1/{addedClientId}", new { clientId = addedClientId });
        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            if (!await _clientService.IsExist(clientId))
            {
                _logger.LogInfo($"Client with id: {clientId} doesn`t exist in the database.");
                return NotFound();
            }

            await _clientService.DeleteClientAsync(_mapper.Map<AddClientModel>(_clientService.GetClientAsync(clientId)));

            return NoContent();
        }

        /// <summary>
        /// Update a client
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateClient(Guid clientId, [FromBody] UpdateClientModel model)
        {
            if (!await _clientService.IsExist(clientId))
            {
                _logger.LogInfo($"Client with id: {clientId} doesn`t exist in the database.");
                return NotFound();
            }
            
            _ = await _clientService.UpdateClientAsync(model);

            return NoContent();
        }
    }
}
