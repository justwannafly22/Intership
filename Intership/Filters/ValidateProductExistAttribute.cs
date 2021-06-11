using System;
using Intership.Abstracts;
using Intership.Abstracts.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Intership.Filters
{
    public class ValidateProductExistAttribute : IAsyncActionFilter
    {
        private readonly IProductService _productLogic;
        private readonly ILoggerManager _logger;

        public ValidateProductExistAttribute(IProductService productLogic, ILoggerManager logger)
        {
            _productLogic = productLogic;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var productId = (Guid)context.ActionArguments["id"];
            var product = await _productLogic.GetProductAsync(productId);

            if (product == null)
            {
                _logger.LogInfo($"Client with id: {productId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("product", product);
                await next();
            }
        }
    }
}
