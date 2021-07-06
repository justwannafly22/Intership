using Intership.Models.RequestModels.ReplacedPart;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/replacedParts")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ReplacedPartController : Controller
    {
        private readonly IReplacedPartService _replacedPartService;

        public ReplacedPartController(IReplacedPartService replacedPartService)
        {
            _replacedPartService = replacedPartService;
        }

        /// <summary>
        /// Returns a replaced parts or empty array if replaced parts don`t exist in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var replacedParts = await _replacedPartService.GetAllAsync();

            return Ok(replacedParts);
        }

        /// <summary>
        /// Returns a replaced part or empty array, also returns 404 status code if replaced part doesn`t exist in the database
        /// </summary>
        /// <param name="replacedPartId"></param>
        /// <returns></returns>
        [HttpGet("{replacedPartId}")]
        public async Task<IActionResult> Get(Guid replacedPartId)
        {
            if (!await _replacedPartService.IsExist(replacedPartId))
            {
                return NotFound($"ReplacedPart with id: {replacedPartId} doesn`t exist in the database.");
            }

            var replacedPart = await _replacedPartService.GetAsync(replacedPartId);

            return Ok(replacedPart);
        }

        /// <summary>
        /// Create a replaced parts and returns added replaced part id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] IEnumerable<AddReplacedPartModel> models)
        {
            var addedReplacedPartsId = await _replacedPartService.CreateManyAsync(models);

            return Created($"api/v1/replacedParts/{addedReplacedPartsId}", new { ReplacedPartsId = addedReplacedPartsId });
        }

        /// <summary>
        /// Update a replaced part and returns 200 status code or 404 one if replaced part doesn`t exist in the database
        /// </summary>
        /// <param name="replacedPartId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{replacedPartId}")]
        public async Task<IActionResult> Update(Guid replacedPartId, [FromBody] UpdateReplacedPartModel model)
        {
            if (!await _replacedPartService.IsExist(replacedPartId))
            {
                return NotFound($"ReplacedPart with id: {replacedPartId} doesn`t exist in the database.");
            }

            _ = await _replacedPartService.UpdateAsync(replacedPartId, model);

            return NoContent();
        }

        /// <summary>
        /// Delete a replaced part and returns 200 status code or 404 one if replaced part doesn`t exist in the database
        /// </summary>
        /// <param name="replacedPartId"></param>
        /// <returns></returns>
        [HttpDelete("{replacedPartId}")]
        public async Task<IActionResult> Delete(Guid replacedPartId)
        {
            if (!await _replacedPartService.IsExist(replacedPartId))
            {
                return NotFound($"ReplacedPart with id: {replacedPartId} doesn`t exist in the database.");
            }

            await _replacedPartService.DeleteAsync(replacedPartId);

            return NoContent();
        }
    }
}
