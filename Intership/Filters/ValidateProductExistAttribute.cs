using System;
using Intership.Abstracts;
using Intership.Abstracts.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Intership.Filters
{
    public class ValidateProductExistAttribute : IAsyncActionFilter
    {
        private readonly IProductService _productService;
        private readonly ILoggerManager _logger;

        public ValidateProductExistAttribute(IProductService productService, ILoggerManager logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var productId = (Guid)context.ActionArguments["productId"];
            var product = await _productService.GetProductAsync(productId);

            if (product == null)
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
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
