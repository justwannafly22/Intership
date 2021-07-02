using Intership.Filters;
using Intership.LoggerService.Abstracts;
using Intership.Models.RequestModels.Product;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Intership.ModelBinders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILoggerManager _logger;

        public ProductController(IProductService productService, ILoggerManager logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();

            return Ok(products);
        }

        /// <summary>
        /// Returns a single product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            if (!await _productService.IsExist(productId))
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(await _productService.GetProductAsync(productId));
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody] AddProductModel model)
        {
            var addedProductId = await _productService.CreateProductAsync(model);

            return Created($"api/v1/products/{addedProductId}", new { productId = addedProductId });
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            if (!await _productService.IsExist(productId))
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
                return NotFound();
            }
            
            await _productService.DeleteProductAsync(productId);
            
            return NoContent();
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] UpdateProductModel model)
        {
            if (!await _productService.IsExist(productId))
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
                return NotFound();
            }

            _ = await _productService.UpdateProductAsync(productId, model);

            return NoContent();
        }

        /// <summary>
        /// Returns all repairs by product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}/repairs")]
        public async Task<IActionResult> GetRepairsByProduct(Guid productId)
        {
            if (!await _productService.IsExist(productId))
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
                return NotFound();
            }

            var repairs = await _productService.GetRepairsByProduct(productId);

            return Ok(repairs);
        }

        /// <summary>
        /// Get repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpGet("{productId}/repairs/{repairId}")]
        public async Task<IActionResult> GetRepairByProduct(Guid productId, Guid repairId)
        {
            if (!await _productService.IsExist(productId))
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
                return NotFound();
            }
            else if (!await _productService.IsExistRepair(productId, repairId))
            {
                _logger.LogInfo($"Repair with id: {repairId} doesn`t exist in the product.");
                return NotFound();
            }

            var repair = await _productService.GetRepairByProduct(productId, repairId);

            return Ok(repair);
        }
    }
}
