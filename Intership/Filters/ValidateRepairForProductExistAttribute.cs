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
    public class ValidateRepairForProductExistAttribute : IAsyncActionFilter
    {
        private readonly IProductService _productService;
        private readonly IRepairService _repairService;
        private readonly ILoggerManager _logger;

        public ValidateRepairForProductExistAttribute(IProductService productService, IRepairService repairService, ILoggerManager logger)
        {
            _productService = productService;
            _repairService = repairService;
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
            
            var repairId = (Guid)context.ActionArguments["repairId"];
            var repair = await _repairService.GetRepairAsync(repairId, productId);

            if(repair == null)
            {
                _logger.LogInfo($"Repair with id: {repairId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("repair", repair);
                await next();
            }
        }
    }
}
