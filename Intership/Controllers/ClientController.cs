using Microsoft.AspNetCore.Mvc;
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
    [ApiExplorerSettings(GroupName = "v1")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ILoggerManager _logger;

        public ClientController(IClientService clientService, ILoggerManager logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        /// <summary>
        /// Returns all clients or empty array if clients don`t exist in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientService.GetAllAsync();

            return Ok(clients);
        }

        /// <summary>
        /// Returns a client or 404 status code if client doesn`t exist in the database
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

            return Ok(await _clientService.GetAsync(clientId));
        }

        /// <summary>
        /// Create a new client and returns added client id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateClient([FromBody] AddClientModel model)
        {
            var addedClientId = await _clientService.CreateAsync(model);

            return Created($"api/v1/{addedClientId}", new { clientId = addedClientId });
        }

        /// <summary>
        /// Delete a client and returns 200 status code or 404 status code if client doesn`t exist in the database
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

            await _clientService.DeleteAsync(clientId);

            return NoContent();
        }

        /// <summary>
        /// Update a client and returns 200 status code or 404 status code if client doesn`t exist in the database
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

            _ = await _clientService.UpdateAsync(clientId, model);

            return NoContent();
        }

        /// <summary>
        /// Returns a repairs for the client or 404 status code if client doesn`t exist in the database
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("{clientId}/repairs")]
        public async Task<IActionResult> GetRepairs(Guid clientId)
        {
            if (!await _clientService.IsExist(clientId))
            {
                _logger.LogInfo($"Client with id: {clientId} doesn`t exist in the database.");
                return NotFound();
            }

            var repairs = await _clientService.GetRepairs(clientId);

            return Ok(repairs);
        }
    }
}
