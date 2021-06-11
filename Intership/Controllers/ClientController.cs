using Intership.Abstracts.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intership.Models.Entities;
using Intership.DTO.Client;
using Intership.Abstracts;
using Intership.Filters;
using Unity;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, ILoggerManager logger, IMapper mapper)
        {
            _clientService = clientService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clientsEntity = await _clientService.GetClientsAsync();

            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clientsEntity);

            return Ok(clientsDto);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClient(Guid clientId)
        {
            var clientEntity = await _clientService.GetClientAsync(clientId);
            if (clientEntity == null) 
            {
                _logger.LogInfo($"Client with id: {clientId} doesn`t exist in the database.");
                return NotFound();
            }

            var clientDto = _mapper.Map<ClientDto>(clientEntity);

            return Ok(clientDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateClient([FromBody] ClientForCreateDto clientDto)
        {
            var clientEntity = _mapper.Map<Client>(clientDto);

            await _clientService.CreateClientAsync(clientEntity);

            return Created($"api/v1/{clientEntity.Id}", new { clientId = clientEntity.Id });
        }

        [HttpDelete("{clientId}")]
        [ServiceFilter(typeof(ValidateClientExistAttribute))]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            var client = HttpContext.Items["client"] as Client;

            await _clientService.DeleteClientAsync(client);

            return NoContent();
        }

        [HttpPut("{clientId}")]
        [ServiceFilter(typeof(ValidateClientExistAttribute))]
        public async Task<IActionResult> UpdateClient(Guid clientId, [FromBody] ClientForUpdateDto clientDto)
        {
            var client = HttpContext.Items["client"] as Client;

            _mapper.Map(clientDto, client);

            await _clientService.UpdateClientAsync(client);

            return NoContent();
        }
    }
}
