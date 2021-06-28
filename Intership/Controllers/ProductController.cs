using AutoMapper;
using Intership.Filters;
using Intership.LoggerService.Abstracts;
using Intership.Models.RequestModels.Product;
using Intership.Models.RequestModels.Repair;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ILoggerManager logger, IMapper mapper)
        {
            _productService = productService;
            _logger = logger;
            _mapper = mapper;
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
        /// Create 
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
            
            await _productService.DeleteProductAsync(_mapper.Map<AddProductModel>(await _productService.GetProductAsync(productId)));
            
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

            _ = await _productService.UpdateProductAsync(model);

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

            var repair = await _productService.GetRepairByProduct(productId, repairId);

            return Ok(repair);
        }

        /// <summary>
        /// Create repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{productId}/repairs")]
        public async Task<IActionResult> CreateRepairForProduct(Guid productId, [FromBody] AddRepairModel model)
        {
            if (!await _productService.IsExist(productId))
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
                return NotFound();
            }

            var addedRepairId = await _productService.CreateRepairForProductAsync(model, productId);

            return Created($"api/v1/{productId}/repairs{addedRepairId}", new { RepairId = addedRepairId });
        }

        /// <summary>
        /// Update a repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{productId}/repairs/{repairId}")]
        public async Task<IActionResult> UpdateRepairForProductAsync(Guid productId, Guid repairId, [FromBody] UpdateRepairModel model)
        {
            if (!await _productService.IsExist(productId))
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
                return NotFound();
            }

            _ = await _productService.UpdateRepairForProductAsync(model, productId, repairId);

            return NoContent();
        }

        /// <summary>
        /// Delete a repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpDelete("{productId}/repairs/{repairId}")]
        public async Task<IActionResult> DeleteRepairForProduct(Guid productId, Guid repairId)
        {
            if (!await _productService.IsExist(productId))
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
                return NotFound();
            }
            
            await _productService.DeleteRepairForProductAsync(productId, repairId);
            
            return NoContent();
        }
    }
}
