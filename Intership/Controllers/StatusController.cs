﻿using AutoMapper;
using Intership.LoggerService.Abstracts;
using Intership.Models.RequestModels.Status;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/statuses")]
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public StatusController (IStatusService statusService, ILoggerManager logger, IMapper mapper)
        {
            _statusService = statusService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all statuses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            var statuses = await _statusService.GetStatusesAsync();

            return Ok(statuses);
        }

        /// <summary>
        /// Returns a status
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        [HttpGet("{statusId}")]
        public async Task<IActionResult> GetStatus(Guid statusId)
        {
            if (!await _statusService.IsExist(statusId))
            {
                _logger.LogInfo($"Status with id: {statusId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(await _statusService.GetStatusAsync(statusId));
        }

        /// <summary>
        /// Create a new status and returns an id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateStatus([FromBody] AddStatusModel model)
        {
            var addedStatusId = await _statusService.CreateStatusAsync(model);

            return Created($"api/v1/{addedStatusId}", new { AddedStatusId = addedStatusId });
        }

        /// <summary>
        /// Delete a status
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        [HttpDelete("{statusId}")]
        public async Task<IActionResult> DeleteStatus(Guid statusId)
        {
            if (!await _statusService.IsExist(statusId))
            {
                _logger.LogInfo($"Status with id: {statusId} doesn`t exist in the database.");
                return NotFound();
            }

            await _statusService.DeleteStatusAsync(_mapper.Map<AddStatusModel>(await _statusService.GetStatusAsync(statusId)));

            return NoContent();
        }

        /// <summary>
        /// Update a status
        /// </summary>
        /// <param name="statusId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{statusId}")]
        public async Task<IActionResult> UpdateStatus(Guid statusId, [FromBody] UpdateStatusModel model)
        {
            if (!await _statusService.IsExist(statusId))
            {
                _logger.LogInfo($"Status with id: {statusId} doesn`t exist in the database.");
                return NotFound();
            }

            _ = await _statusService.UpdateStatusAsync(model);

            return NoContent();
        }
    }
}
