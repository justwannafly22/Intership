using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Intership.Services.Abstracts;
using Intership.Models.RequestModels.Client;
using System.Linq;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/clients")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Returns all clients or empty array if clients don`t exist in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllAsync();

            return Ok(clients);
        }

        /// <summary>
        /// Returns a client or 404 status code if client doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!await _clientService.IsExist(id)) 
            {
                return NotFound($"Client with id: {id} doesn`t exist in the database.");
            }

            var client = await _clientService.GetAsync(id);

            return Ok(client);
        }

        /// <summary>
        /// Create a new client and returns added client id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddClientModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedClientId = await _clientService.CreateAsync(model);

            return CreatedAtRoute("Get", new { id = addedClientId });
        }

        /// <summary>
        /// Delete a client and returns 200 status code or 404 status code if client doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!await _clientService.IsExist(id))
            {
                return NotFound($"Client with id: {id} doesn`t exist in the database.");
            }

            await _clientService.DeleteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Update a client and returns 200 status code or 404 status code if client doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateClientModel model)
        {
            if (!await _clientService.IsExist(id))
            {
                return NotFound($"Client with id: {id} doesn`t exist in the database.");
            }

            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var updatedClientId = await _clientService.UpdateAsync(id, model);

            return RedirectToAction("Get", "ClientController", new { id = updatedClientId });
        }

        /// <summary>
        /// Returns a repairs for the client or 404 status code if client doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/repairs")]
        public async Task<IActionResult> GetRepairs([FromRoute] Guid id)
        {
            if (!await _clientService.IsExist(id))
            {
                return NotFound($"Client with id: {id} doesn`t exist in the database.");
            }

            var repairs = await _clientService.GetRepairs(id);

            return Ok(repairs);
        }
    }
}
