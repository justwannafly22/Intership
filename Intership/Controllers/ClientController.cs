using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Intership.Services.Abstracts;
using Intership.Models.RequestModels.Client;
using System.Linq;
using Intership.Models.ResponseModels;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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
        /// Returns all clients
        /// </summary>
        /// <response code="200">Success. Clients were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<ClientResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllAsync();

            return Ok(clients);
        }

        /// <summary>
        /// Returns a client
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Client model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Client with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ClientResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!await _clientService.IsExist(id)) 
            {
                return NotFound(new BaseResponseModel($"Client with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            var client = await _clientService.GetAsync(id);

            return Ok(client);
        }

        /// <summary>
        /// Create a client
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Status model was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ClientResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddClientModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedClient = await _clientService.CreateAsync(model);

            return CreatedAtAction(nameof(Get), new { id = addedClient.Id }, addedClient);
        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Client was deleted successfully</response>
        /// <response code="404">Client with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!await _clientService.IsExist(id))
            {
                return NotFound(new BaseResponseModel($"Client with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            await _clientService.DeleteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Update a client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <response code="200">Client was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Client with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(ClientResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateClientModel model)
        {
            if (!await _clientService.IsExist(id))
            {
                return NotFound(new BaseResponseModel($"Client with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var updatedClientId = await _clientService.UpdateAsync(id, model);

            return RedirectToAction(nameof(Get), new { id = updatedClientId});
        }

        /// <summary>
        /// Returns a repairs for the client
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Repairs were received successfully</response>
        /// <response code="404">Client with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<RepairResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}/repairs")]
        public async Task<IActionResult> GetRepairs([FromRoute] Guid id)
        {
            if (!await _clientService.IsExist(id))
            {
                return NotFound(new BaseResponseModel($"Client with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            var repairs = await _clientService.GetRepairs(id);

            return Ok(repairs);
        }
    }
}
