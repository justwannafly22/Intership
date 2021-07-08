using Intership.Models.RequestModels.Status;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        /// Returns all statuses or empty array if statuses doesn`t exist in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statuses = await _statusService.GetAllAsync();

            return Ok(statuses);
        }

        /// <summary>
        /// Returns a status or 404 status code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!await _statusService.IsExist(id))
            {
                return NotFound($"Status with id: {id} doesn`t exist in the database.");
            }

            var status = await _statusService.GetAsync(id);

            return Ok(status);
        }

        /// <summary>
        /// Create a new status and returns an id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddStatusModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedStatusId = await _statusService.CreateAsync(model);

            return CreatedAtRoute($"Get", new { id = addedStatusId });
        }

        /// <summary>
        /// Delete a status and returns 200 or 404 status code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _statusService.IsExist(id))
            {
                return NotFound($"Status with id: {id} doesn`t exist in the database.");
            }

            await _statusService.DeleteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Update a status and returns 200 or 404 status code
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStatusModel model)
        {
            if (!await _statusService.IsExist(id))
            {
                return NotFound($"Status with id: {id} doesn`t exist in the database.");
            }

            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var updatedStatusId = await _statusService.UpdateAsync(id, model);

            return RedirectToAction("Get", "StatusController", new { id = updatedStatusId });
        }
    }
}
