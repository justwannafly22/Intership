using Intership.Models.RequestModels.Status;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/statuses")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        /// <summary>
        /// Returns all statuses 
        /// </summary>
        /// <response code="200">Success. Statuses were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<StatusResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statuses = await _statusService.GetAllAsync();

            return Ok(statuses);
        }

        /// <summary>
        /// Returns a status
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Status model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Status with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(StatusResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var status = await _statusService.GetAsync(id);

            if (status == null)
            {
                return NotFound(new BaseResponseModel($"Status with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            return Ok(status);
        }

        /// <summary>
        /// Create a new status and returns an id
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Status model was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(AddedResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddStatusModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedStatus = await _statusService.CreateAsync(model);

            return CreatedAtRoute(nameof(Get), new { id = addedStatus.Id }, addedStatus);
        }

        /// <summary>
        /// Delete a status
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Status was deleted successfully</response>
        /// <response code="404">Status with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _statusService.IsExist(id))
            {
                return NotFound(new BaseResponseModel($"Status with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            await _statusService.DeleteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Update a status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <response code="200">Status was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Status with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStatusModel model)
        {
            if (!await _statusService.IsExist(id))
            {
                return NotFound(new BaseResponseModel($"Status with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var updatedStatusId = await _statusService.UpdateAsync(id, model);

            return RedirectToAction(nameof(Get), new { id = updatedStatusId });
        }
    }
}
