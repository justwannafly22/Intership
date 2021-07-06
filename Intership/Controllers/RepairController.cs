using Intership.Filters;
using Intership.LoggerService.Abstracts;
using Intership.Models.RequestModels.Repair;
using Intership.Models.RequestModels.RepairInfo;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/repairs")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RepairController : Controller
    {
        private readonly IRepairService _repairService;
        private readonly IRepairInfoService _repairInfoService;
        private readonly ILoggerManager _logger;

        public RepairController(IRepairService repairService, IRepairInfoService repairInfoService, ILoggerManager logger)
        {
            _repairService = repairService;
            _repairInfoService = repairInfoService;
            _logger = logger;
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
        [HttpGet("{repairId}")]
        public async Task<IActionResult> GetRepair(Guid repairId)
        {
            if (!await _repairService.IsExist(repairId))
            {
                _logger.LogInfo($"Repair with id: {repairId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(await _repairService.GetAsync(repairId));
        }

        /// <summary>
        /// Create a repair and returns added repair id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create([FromBody] AddRepairModel model)
        {
            var addedRepairId = await _repairService.CreateAsync(model);

            return Created($"api/v1/repairs/{addedRepairId}", new { RepairId = addedRepairId });
        }

        /// <summary>
        /// Update a repair and returns 200 status code or 404 one if repair doesn`t exist in the database
        /// </summary>
        /// <param name="repairId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{repairId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(Guid repairId, [FromBody] UpdateRepairModel model)
        {
            if (!await _repairService.IsExist(repairId))
            {
                _logger.LogInfo($"Repair with id: {repairId} doesn`t exist in the database.");
                return NotFound();
            }

            _ = await _repairService.UpdateAsync(repairId, model);

            return NoContent();
        }

        /// <summary>
        /// Delete a repair and repair info and returns a 200 status code or 404 one if repair doesn`t exist in the database
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpDelete("{repairId}")]
        public async Task<IActionResult> Delete(Guid repairId)
        {
            if (!await _repairService.IsExist(repairId))
            {
                _logger.LogInfo($"Repair with id: {repairId} doesn`t exist in the database.");
                return NotFound();
            }

            await _repairService.DeleteAsync(repairId);

            return NoContent();
        }
        
        /// <summary>
        /// Create a repair info for the repair and returns adder repair id
        /// </summary>
        /// <param name="repairId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{repairId}/repairsInfo")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create(Guid repairId, [FromBody] AddRepairInfoModel model)
        {
            var addedRepairInfoId = await _repairInfoService.CreateAsync(model, repairId);

            return Created($"api/v1/repairs/{repairId}/repairsInfo/{addedRepairInfoId}", new { RepairId = repairId, RepairInfoId = addedRepairInfoId });
        }

        /// <summary>
        /// Returns a replaced parts for the repair or 404 status code if repair doesn`t exist in the database
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpGet("{repairId}/replacedParts")]
        public async Task<IActionResult> GetAllForRepair(Guid repairId)
        {
            if (!await _repairService.IsExist(repairId))
            {
                _logger.LogInfo($"Repair with id: {repairId} doesn`t exist in the database.");
                return NotFound();
            }

            var replacedParts = await _repairService.GetAllForRepair(repairId);

            return Ok(replacedParts);
        }
    }
}
