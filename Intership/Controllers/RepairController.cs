using AutoMapper;
using Intership.Models.RequestModels.Repair;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        /// Returns all repairs or empty array if repairs don`t exist in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRepairs()
        {
            var repairs = await _repairService.GetAllAsync();

            return Ok(repairs);
        }

        /// <summary>
        /// Returns a repair or 404 status code if repair doesn`t exist in the database
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetRepair")]
        public async Task<IActionResult> GetRepair(Guid id)
        {
            if (!await _repairService.IsExist(id))
            {
                return NotFound($"Repair with id: {id} doesn`t exist in the database.");
            }

            return Ok(await _repairService.GetAsync(id));
        }

        /// <summary>
        /// Create a repair and returns added repair id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRepairModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedRepairId = await _repairService.CreateAsync(model);

            return CreatedAtRoute($"GetRepair", new { id = addedRepairId });
        }

        /// <summary>
        /// Update a repair and returns 200 status code or 404 one if repair doesn`t exist in the database
        /// </summary>
        /// <param name="repairId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRepairModel model)
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

            return RedirectToAction("GetRepair", "RepairController", new { id = updatedRepairId });
        }

        /// <summary>
        /// Delete a repair and repair info and returns a 200 status code or 404 one if repair doesn`t exist in the database
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _repairService.IsExist(id))
            {
                return NotFound($"Repair with id: {id} doesn`t exist in the database.");
            }

            await _repairService.DeleteAsync(id);

            return NoContent();
        }
        
        /// <summary>
        /// Returns a replaced parts for the repair or 404 status code if repair doesn`t exist in the database
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpGet("{id}/replacedParts")]
        public async Task<IActionResult> GetAllForRepair(Guid id)
        {
            if (!await _repairService.IsExist(id))
            {
                return NotFound($"Repair with id: {id} doesn`t exist in the database.");
            }

            var replacedParts = await _repairService.GetAllReplacedParts(id);

            return Ok(replacedParts);
        }

        /// <summary>
        /// Update a status and 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchModel"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStatus([FromRoute]Guid id, [FromBody] JsonPatchDocument<UpdateRepairModel> patchModel)//test
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
