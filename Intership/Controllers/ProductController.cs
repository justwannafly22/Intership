using Intership.Filters;
using Intership.Models.RequestModels.Product;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Intership.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Returns all products or empty array if products doesn`t exist in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        /// <summary>
        /// Returns a product or 404 status code if product doesn`t exist in the database
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(Guid productId)
        {
            if (!await _productService.IsExist(productId))
            {
                return NotFound($"Product with id: {productId} doesn`t exist in the database.");
            }

            return Ok(await _productService.GetAsync(productId));
        }

        /// <summary>
        /// Create a product and returns added product id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProductModel model)
        {
            var addedProductId = await _productService.CreateAsync(model);

            return Created($"api/v1/products/{addedProductId}", new { productId = addedProductId });
        }

        /// <summary>
        /// Delete a product and returns 200 status code or 404 status code if product doesn`t exist in the database
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            if (!await _productService.IsExist(productId))
            {
                return NotFound($"Product with id: {productId} doesn`t exist in the database.");
            }
            
            await _productService.DeleteAsync(productId);
            
            return NoContent();
        }

        /// <summary>
        /// Update a product and returns 200 status code or 404 status code if product doesn`t exist in the database
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{productId}")]
        public async Task<IActionResult> Update(Guid productId, [FromBody] UpdateProductModel model)
        {
            if (!await _productService.IsExist(productId))
            {
                return NotFound($"Product with id: {productId} doesn`t exist in the database.");
            }

            _ = await _productService.UpdateAsync(productId, model);

            return NoContent();
        }

        /// <summary>
        /// Returns all repairs by product or 404 status code if product doesn`t exist in the database
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}/repairs")]
        public async Task<IActionResult> GetRepairsByProduct(Guid productId)
        {
            if (!await _productService.IsExist(productId))
            {
                return NotFound($"Product with id: {productId} doesn`t exist in the database.");
            }

            var repairs = await _productService.GetRepairsByProduct(productId);

            return Ok(repairs);
        }

        /// <summary>
        /// Get repair for the product and returns 404 status code if product or repair doesn`t exist in the database
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpGet("{productId}/repairs/{repairId}")]
        public async Task<IActionResult> GetRepairByProduct(Guid productId, Guid repairId)//wrong realization
        {
            if (!await _productService.IsExist(productId))
            {
                return NotFound($"Product with id: {productId} doesn`t exist in the database.");
            }
            else if (!await _productService.IsRepairExist(productId, repairId))
            {
                return NotFound();
            }

            var repair = await _productService.GetRepairByProduct(productId, repairId);

            return Ok(repair);
        }
    }
}
