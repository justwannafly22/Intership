using AutoMapper;
using Intership.LoggerService.Abstracts;
using Intership.Models.RequestModels.ReplacedPart;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/replacedParts")]
    public class ReplacedPartController : Controller
    {
        private readonly IReplacedPartService _replacedPartService;
        private readonly ILoggerManager _logger;

        public ReplacedPartController(IReplacedPartService replacedPartService, ILoggerManager logger)
        {
            _replacedPartService = replacedPartService;
            _logger = logger;
        }

        /// <summary>
        /// Returns a replaced parts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetReplacedParts()
        {
            var replacedParts = await _replacedPartService.GetReplacedPartsAsync();

            return Ok(replacedParts);
        }

        /// <summary>
        /// Returns a replaced part
        /// </summary>
        /// <param name="replacedPartId"></param>
        /// <returns></returns>
        [HttpGet("{replacedPartId}")]
        public async Task<IActionResult> GetReplacedPart(Guid replacedPartId)
        {
            if (!await _replacedPartService.IsExist(replacedPartId))
            {
                _logger.LogInfo($"ReplacedPart with id: {replacedPartId} doesn`t exist in the database.");
                return NotFound();
            }

            var replacedPart = await _replacedPartService.GetReplacedPartAsync(replacedPartId);

            return Ok(replacedPart);
        }

        /// <summary>
        /// Create a replaced parts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> CreateReplacedParts([FromBody] IEnumerable<AddReplacedPartModel> models)
        {
            var addedReplacedPartsId = await _replacedPartService.CreateReplacedPartsAsync(models);

            return Created($"api/v1/replacedParts/{addedReplacedPartsId}", new { ReplacedPartsId = addedReplacedPartsId });
        }

        /// <summary>
        /// Update a replaced part
        /// </summary>
        /// <param name="replacedPartId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{replacedPartId}")]
        public async Task<IActionResult> UpdateReplacedPart(Guid replacedPartId, [FromBody] UpdateReplacedPartModel model)
        {
            if (!await _replacedPartService.IsExist(replacedPartId))
            {
                _logger.LogInfo($"ReplacedPart with id: {replacedPartId} doesn`t exist in the database.");
                return NotFound();
            }

            _ = await _replacedPartService.UpdateReplacedPartAsync(replacedPartId, model);

            return NoContent();
        }

        /// <summary>
        /// Delete a replaced part
        /// </summary>
        /// <param name="replacedPartId"></param>
        /// <returns></returns>
        [HttpDelete("{replacedPartId}")]
        public async Task<IActionResult> DeleteReplacedPart(Guid replacedPartId)
        {
            if (!await _replacedPartService.IsExist(replacedPartId))
            {
                _logger.LogInfo($"ReplacedPart with id: {replacedPartId} doesn`t exist in the database.");
                return NotFound();
            }

            await _replacedPartService.DeleteReplacedPartAsync(replacedPartId);

            return NoContent();
        }
    }
}
