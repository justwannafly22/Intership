using Intership.LoggerService.Abstracts;
using Intership.Models.RequestModels.Status;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/statuses")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;
        private readonly ILoggerManager _logger;

        public StatusController (IStatusService statusService, ILoggerManager logger)
        {
            _statusService = statusService;
            _logger = logger;
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
        /// <param name="statusId"></param>
        /// <returns></returns>
        [HttpGet("{statusId}")]
        public async Task<IActionResult> Get(Guid statusId)
        {
            if (!await _statusService.IsExist(statusId))
            {
                _logger.LogInfo($"Status with id: {statusId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(await _statusService.GetAsync(statusId));
        }

        /// <summary>
        /// Create a new status and returns an id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddStatusModel model)
        {
            var addedStatusId = await _statusService.CreateAsync(model);

            return Created($"api/v1/{addedStatusId}", new { AddedStatusId = addedStatusId });
        }

        /// <summary>
        /// Delete a status and returns 200 or 404 status code
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        [HttpDelete("{statusId}")]
        public async Task<IActionResult> Delete(Guid statusId)
        {
            if (!await _statusService.IsExist(statusId))
            {
                _logger.LogInfo($"Status with id: {statusId} doesn`t exist in the database.");
                return NotFound();
            }

            await _statusService.DeleteAsync(statusId);

            return NoContent();
        }

        /// <summary>
        /// Update a status and returns 200 or 404 status code
        /// </summary>
        /// <param name="statusId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{statusId}")]
        public async Task<IActionResult> Update(Guid statusId, [FromBody] UpdateStatusModel model)
        {
            if (!await _statusService.IsExist(statusId))
            {
                _logger.LogInfo($"Status with id: {statusId} doesn`t exist in the database.");
                return NotFound();
            }

            _ = await _statusService.UpdateAsync(statusId, model);

            return NoContent();
        }
    }
}
