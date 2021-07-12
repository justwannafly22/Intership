using AutoMapper;
using Intership.Models.RequestModels.Repair;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/repairs")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RepairController : Controller
    {
        private readonly IRepairService _repairService;
        private readonly IMapper _mapper;

        public RepairController(IRepairService repairService, IMapper mapper)
        {
            _repairService = repairService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all repairs
        /// </summary>
        /// <response code="200">Success. Repairs were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<RepairResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var repairs = await _repairService.GetAllAsync();

            return Ok(repairs);
        }

        /// <summary>
        /// Returns a repair
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Repair model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Repair with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(RepairResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!await _repairService.IsExist(id))
            {
                return NotFound($"Repair with id: {id} doesn`t exist in the database.");
            }

            var repair = await _repairService.GetAsync(id);

            return Ok(repair);
        }

        /// <summary>
        /// Create a repair
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Repair model was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(RepairResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRepairModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedRepairId = await _repairService.CreateAsync(model);

            return CreatedAtAction("Get", new { id = addedRepairId }, new AddedResponseModel(addedRepairId, HttpStatusCode.Created));
        }

        /// <summary>
        /// Update a repair
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <response code="200">Repair was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Repair with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRepairModel model)
        {
            if (!await _repairService.IsExist(id))
            {
                return NotFound($"Repair with id: {id} doesn`t exist in the database.");
            }

            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var updatedRepairId = await _repairService.UpdateAsync(id, model);

            return RedirectToAction("Get", new { id = updatedRepairId });
        }

        /// <summary>
        /// Delete a repair and repair info
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Repair was deleted successfully</response>
        /// <response code="404">Repair with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!await _repairService.IsExist(id))
            {
                return NotFound($"Repair with id: {id} doesn`t exist in the database.");
            }

            await _repairService.DeleteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Returns a replaced parts for the repair
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Replaced parts were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<ReplacedPartResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}/replacedParts")]
        public async Task<IActionResult> GetAllForRepair([FromRoute] Guid id)
        {
            if (!await _repairService.IsExist(id))
            {
                return NotFound($"Repair with id: {id} doesn`t exist in the database.");
            }

            var replacedParts = await _repairService.GetAllReplacedParts(id);

            return Ok(replacedParts);
        }

        /// <summary>
        /// Update a status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchModel"></param>
        /// <response code="200">Repair was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Repair with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromBody] JsonPatchDocument<UpdateRepairModel> patchModel)//test
        {
            if (!await _repairService.IsExist(id))
            {
                return NotFound($"Repair with id: {id} doesn`t exist in the database.");
            }

            var model = _mapper.Map<UpdateRepairModel>(await _repairService.GetAsync(id));
            patchModel.ApplyTo(model);

            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var updatedRepairId = await _repairService.UpdateAsync(id, model);

            return RedirectToAction("GetRepair", "RepairController", new { id = updatedRepairId });
        }
    }
}
