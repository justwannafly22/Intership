using Intership.Abstracts.Logic;
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
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientLogic _clientLogic;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ClientController(IClientLogic clientLogic, ILoggerManager logger, IMapper mapper)
        {
            _clientLogic = clientLogic;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clientsEntity = await _clientLogic.GetClientsAsync();

            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clientsEntity);

            return Ok(clientsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            var clientEntity = await _clientLogic.GetClientAsync(id);
            if (clientEntity == null) 
            {
                _logger.LogInfo($"Client with id: {id} doesn`t exist in the database.");
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

            await _clientLogic.CreateClientAsync(clientEntity);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateClientExistAttribute))]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = HttpContext.Items["client"] as Client;

            await _clientLogic.DeleteClientAsync(client);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateClientExistAttribute))]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] ClientForUpdateDto clientDto)
        {
            var client = HttpContext.Items["client"] as Client;

            _mapper.Map(clientDto, client);

            await _clientLogic.UpdateClientAsync(client);

            return NoContent();
        }
    }
}
