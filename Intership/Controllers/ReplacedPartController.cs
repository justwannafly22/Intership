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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!await _replacedPartService.IsExist(id))
            {
                return NotFound($"ReplacedPart with id: {id} doesn`t exist in the database.");
            }

            var replacedPart = await _replacedPartService.GetAsync(id);

            return Ok(replacedPart);
        }

        /// <summary>
        /// Create a replaced parts and returns added replaced part id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IEnumerable<AddReplacedPartModel> models)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedReplacedPartsId = await _replacedPartService.CreateManyAsync(models);

            return CreatedAtRoute("Get", new { id = addedReplacedPartsId });
        }

        /// <summary>
        /// Update a replaced part and returns 200 status code or 404 one if replaced part doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateReplacedPartModel model)
        {
            if (!await _replacedPartService.IsExist(id))
            {
                return NotFound($"ReplacedPart with id: {id} doesn`t exist in the database.");
            }

            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var updatedReplacedPartId = await _replacedPartService.UpdateAsync(id, model);

            return RedirectToAction("Get", "ReplacedPartController", new { id = updatedReplacedPartId });
        }

        /// <summary>
        /// Delete a replaced part and returns 200 status code or 404 one if replaced part doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!await _replacedPartService.IsExist(id))
            {
                return NotFound($"ReplacedPart with id: {id} doesn`t exist in the database.");
            }

            await _replacedPartService.DeleteAsync(id);

            return NoContent();
        }
    }
}
