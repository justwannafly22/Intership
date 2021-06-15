using AutoMapper;
using Intership.Abstracts;
using Intership.Abstracts.Services;
using Intership.DTO.Repair;
using Intership.Filters;
using Intership.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/products/{productId}/repairs")]
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

        [HttpGet]
        [ServiceFilter(typeof(ValidateProductExistAttribute))]
        public async Task<IActionResult> GetRepairs(Guid productId)
        {
            var repairsEntity = await _repairService.GetRepairsAsync(productId);

            var repairsDto = _mapper.Map<IEnumerable<RepairDto>>(repairsEntity);

            return Ok(repairsDto);
        }

        [HttpGet("{repairId}")]
        [ServiceFilter(typeof(ValidateProductExistAttribute))]
        public async Task<IActionResult> GetRepair(Guid productId, Guid repairId)
        {
            var repairEntity = await _repairService.GetRepairAsync(repairId, productId);
            if (repairEntity == null) 
            {
                _logger.LogInfo($"Repair with id: {repairId} doesn`t exist in the database.");
                return NotFound();
            }

            var repairDto = _mapper.Map<RepairDto>(repairEntity);

            return Ok(repairDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProductExistAttribute))]
        public async Task<IActionResult> CreateRepair(Guid productId, [FromBody] RepairForCreateDto repairDto)
        {
            var repairEntity = _mapper.Map<Repair>(repairDto);

            await _repairService.CreateRepairAsync(productId, repairEntity);

            var repairInfoEntity = _mapper.Map<RepairInfo>(repairDto);
            
            await _repairInfoService.CreateRepairInfoAsync(repairEntity.Id, repairInfoEntity);//mistake occured;
            
            return Created($"api/v1/products/{productId}/repairs/{repairEntity.Id}", new { repair = repairEntity });
        }

        [HttpPut("{repairId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateRepairForProductExistAttribute))]
        public async Task<IActionResult> UpdateRepair(Guid productId, Guid repairId, [FromBody] RepairForUpdateDto repairDto)
        {
            var repairEntity = HttpContext.Items["repair"] as Repair;

            _mapper.Map(repairDto, repairEntity);

            await _repairService.UpdateRepairAsync(repairEntity);

            return NoContent();
        }

        [HttpDelete("{repairId}")]
        [ServiceFilter(typeof(ValidateRepairForProductExistAttribute))]
        public async Task<IActionResult> DeleteRepair(Guid productId, Guid repairId)
        {
            var repairEntity = HttpContext.Items["repair"] as Repair;

            await _repairService.DeleteRepairAsync(repairEntity);

            return NoContent();
        }
    }
}
