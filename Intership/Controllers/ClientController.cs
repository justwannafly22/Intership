using Intership.Abstracts.Logic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intership.Models.Entities;
using Intership.DTO.Client;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientLogic _clientLogic;
        private readonly IMapper _mapper;

        public ClientController(IClientLogic clientLogic, IMapper mapper)
        {
            _clientLogic = clientLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clientsEntity = await _clientLogic.GetClientsAsync();

            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clientsEntity);

            return Ok(clientsDto);
        }

    }
}
