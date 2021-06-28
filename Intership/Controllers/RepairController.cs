using AutoMapper;
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
    public class RepairController : Controller
    {
        private readonly IRepairService _repairService;
        private readonly IRepairInfoService _repairInfoService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public RepairController(IRepairService repairService, IRepairInfoService repairInfoService, ILoggerManager logger, IMapper mapper)
        {
            _repairService = repairService;
            _repairInfoService = repairInfoService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a repairs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRepairs()
        {
            var repairs = await _repairService.GetRepairsAsync();

            return Ok(repairs);
        }

        /// <summary>
        /// Returns a single repair
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

            return Ok(await _repairService.GetRepairAsync(repairId));
        }

        /// <summary>
        /// Create a repair
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRepair([FromBody] AddRepairModel model)
        {
            var addedRepairId = await _repairService.CreateRepairAsync(model);

            return Created($"api/v1/repairs/{addedRepairId}", new { RepairId = addedRepairId });
        }

        /// <summary>
        /// Update a repair
        /// </summary>
        /// <param name="repairId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{repairId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateRepair(Guid repairId, [FromBody] UpdateRepairModel model)
        {
            if (!await _repairService.IsExist(repairId))
            {
                _logger.LogInfo($"Repair with id: {repairId} doesn`t exist in the database.");
                return NotFound();
            }

            _ = await _repairService.UpdateRepairAsync(model);

            return NoContent();
        }

        /// <summary>
        /// Delete a repair and repair info
        /// </summary>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpDelete("{repairId}")]
        public async Task<IActionResult> DeleteRepair(Guid repairId)
        {
            if (!await _repairService.IsExist(repairId))
            {
                _logger.LogInfo($"Repair with id: {repairId} doesn`t exist in the database.");
                return NotFound();
            }

            await _repairService.DeleteRepairAsync(_mapper.Map<AddRepairModel>(await _repairService.GetRepairAsync(repairId)));

            return NoContent();
        }
        
        /// <summary>
        /// Create a repair info for the repair
        /// </summary>
        /// <param name="repairId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{repairId}/repairsInfo")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRepairInfo(Guid repairId, [FromBody] AddRepairInfoModel model)
        {
            var addedRepairInfoId = await _repairInfoService.CreateRepairInfoAsync(model, repairId);

            return Created($"api/v1/repairs/{repairId}/repairsInfo/{addedRepairInfoId}", new { RepairId = repairId, RepairInfoId = addedRepairInfoId });
        }
    }
}
