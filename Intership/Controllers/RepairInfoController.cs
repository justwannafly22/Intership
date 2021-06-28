using AutoMapper;
using Intership.LoggerService.Abstracts;
using Intership.Models.RequestModels.RepairInfo;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/repairsInfo")]
    public class RepairInfoController : Controller
    {
        private readonly IRepairInfoService _repairInfoService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public RepairInfoController (IRepairInfoService repairInfoService, ILoggerManager logger, IMapper mapper)
        {
            _repairInfoService = repairInfoService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a repair info
        /// </summary>
        /// <param name="repairInfoId"></param>
        /// <returns></returns>
        [HttpGet("{repairInfoId}")]
        public async Task<IActionResult> GetRepairInfo(Guid repairInfoId)
        {
            if (!await _repairInfoService.IsExist(repairInfoId))
            {
                _logger.LogInfo($"RepairInfo with id: {repairInfoId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(await _repairInfoService.GetRepairInfoAsync(repairInfoId));
        }

        /// <summary>
        /// Delete a repair info
        /// </summary>
        /// <param name="repairInfoId"></param>
        /// <returns></returns>
        [HttpDelete("{repairInfoId}")]
        public async Task<IActionResult> DeleteRepairInfo(Guid repairInfoId)
        {
            if (!await _repairInfoService.IsExist(repairInfoId))
            {
                _logger.LogInfo($"RepairInfo with id: {repairInfoId} doesn`t exist in the database.");
                return NotFound();
            }

            await _repairInfoService.DeleteRepairInfoAsync(_mapper.Map<AddRepairInfoModel>(await _repairInfoService.GetRepairInfoAsync(repairInfoId)));

            return NoContent();
        }

        /// <summary>
        /// Update a repair info
        /// </summary>
        /// <param name="repairInfoId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{repairInfoId}")]
        public async Task<IActionResult> UpdateRepairInfo(Guid repairInfoId, [FromBody] UpdateRepairInfoModel model)
        {
            if (!await _repairInfoService.IsExist(repairInfoId))
            {
                _logger.LogInfo($"RepairInfo with id: {repairInfoId} doesn`t exist in the database.");
                return NotFound();
            }

            _ = await _repairInfoService.UpdateRepairInfoAsync(model);

            return NoContent();
        }
    }
}
