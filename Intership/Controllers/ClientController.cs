using Intership.Abstracts.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientLogic _clientLogic;

        public ClientController(IClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
        }



    }
}
