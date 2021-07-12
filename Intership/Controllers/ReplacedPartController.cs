using Intership.Models.RequestModels.ReplacedPart;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Http;
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
        /// Returns a replaced parts
        /// </summary>
        /// <response code="200">Success. Replaced parts were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<ReplacedPartResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var replacedParts = await _replacedPartService.GetAllAsync();

            return Ok(replacedParts);
        }

        /// <summary>
        /// Returns a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Replaced part model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Replaced part  with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ReplacedPartResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
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
        /// Create a replaced parts
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Replaced part models were created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<ReplacedPartResponseModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<AddReplacedPartModel> models)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedReplacedPartsId = await _replacedPartService.CreateManyAsync(models);

            return CreatedAtAction("Get", new { id = addedReplacedPartsId });
        }

        /// <summary>
        /// Update a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <response code="200">Replaced part was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Replaced part with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
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

            return RedirectToAction("Get",  new { id = updatedReplacedPartId });
        }

        /// <summary>
        /// Delete a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Replaced part was deleted successfully</response>
        /// <response code="404">Replaced part with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
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
