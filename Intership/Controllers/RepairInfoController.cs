using Intership.Models.RequestModels.RepairInfo;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/repairsInfo")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RepairInfoController : Controller
    {
        private readonly IRepairInfoService _repairInfoService;

        public RepairInfoController (IRepairInfoService repairInfoService)
        {
            _repairInfoService = repairInfoService;
        }

        /// <summary>
        /// Returns a repair info or 404 status code if repair info doesn`t exist in the database
        /// </summary>
        /// <param name="repairInfoId"></param>
        /// <returns></returns>
        [HttpGet("{repairInfoId}")]
        public async Task<IActionResult> Get(Guid repairInfoId)
        {
            if (!await _repairInfoService.IsExist(repairInfoId))
            {
                return NotFound($"RepairInfo with id: {repairInfoId} doesn`t exist in the database.");
            }

            return Ok(await _repairInfoService.GetAsync(repairInfoId));
        }

        /// <summary>
        /// Delete a repair info and returns 200 status code or 404 one if repair info doesn`t exist in the database
        /// </summary>
        /// <param name="repairInfoId"></param>
        /// <returns></returns>
        [HttpDelete("{repairInfoId}")]
        public async Task<IActionResult> Delete(Guid repairInfoId)
        {
            if (!await _repairInfoService.IsExist(repairInfoId))
            {
                return NotFound($"RepairInfo with id: {repairInfoId} doesn`t exist in the database.");
            }

            await _repairInfoService.DeleteAsync(repairInfoId);

            return NoContent();
        }

        /// <summary>
        /// Update a repair info and returns 200 status code or 404 one if repair info doesn`t exist in the database
        /// </summary>
        /// <param name="repairInfoId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{repairInfoId}")]
        public async Task<IActionResult> Update(Guid repairInfoId, [FromBody] UpdateRepairInfoModel model)
        {
            if (!await _repairInfoService.IsExist(repairInfoId))
            {
                return NotFound($"RepairInfo with id: {repairInfoId} doesn`t exist in the database.");
            }

            _ = await _repairInfoService.UpdateAsync(repairInfoId, model);
            
            return NoContent();
        }
    }
}
