using Intership.Abstracts;
using Intership.Abstracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Filters
{
    public class ValidateClientExistAttribute : IAsyncActionFilter
    {
        private readonly IClientService _clientService;
        private readonly ILoggerManager _logger;

        public ValidateClientExistAttribute(IClientService clientService, ILoggerManager logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var clientId = (Guid)context.ActionArguments["clientId"];
            var client = await _clientService.GetClientAsync(clientId);

            if(client == null)
            {
                _logger.LogInfo($"Client with id: {clientId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("client", client);
                await next();
            }
        }
    }
}
