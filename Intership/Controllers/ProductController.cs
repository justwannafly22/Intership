using Intership.Filters;
using Intership.Models.RequestModels.Product;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!await _productService.IsExist(id))
            {
                return NotFound($"Product with id: {id} doesn`t exist in the database.");
            }

            var product = await _productService.GetAsync(id);

            return Ok(product);
        }

        /// <summary>
        /// Create a product and returns added product id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProductModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedProductId = await _productService.CreateAsync(model);

            return CreatedAtRoute("Get", new { productId = addedProductId });
        }

        /// <summary>
        /// Delete a product and returns 200 status code or 404 status code if product doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!await _productService.IsExist(id))
            {
                return NotFound($"Product with id: {id} doesn`t exist in the database.");
            }
            
            await _productService.DeleteAsync(id);
            
            return NoContent();
        }

        /// <summary>
        /// Update a product and returns 200 status code or 404 status code if product doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductModel model)
        {
            if (!await _productService.IsExist(id))
            {
                return NotFound($"Product with id: {id} doesn`t exist in the database.");
            }

            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var updatedProductId = await _productService.UpdateAsync(id, model);

            return RedirectToAction("Get", "ProductController", new { id = updatedProductId });
        }

        /// <summary>
        /// Returns all repairs by product or 404 status code if product doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/repairs")]
        public async Task<IActionResult> GetRepairsByProduct([FromRoute] Guid id)
        {
            if (!await _productService.IsExist(id))
            {
                return NotFound($"Product with id: {id} doesn`t exist in the database.");
            }

            var repairs = await _productService.GetRepairsByProduct(id);

            return Ok(repairs);
        }

        /// <summary>
        /// Get repair for the product and returns 404 status code if product or repair doesn`t exist in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        [HttpGet("{id}/repairs/{repairId}")]
        public async Task<IActionResult> GetRepair([FromRoute] Guid id, [FromRoute] Guid repairId)
        {
            if (!await _productService.IsRepairExist(id, repairId))
            {
                return NotFound($"Repair with id: {repairId} doesn`t exist in the product.");
            }

            var repair = await _productService.GetRepairByProduct(id, repairId);
            
            return Ok(repair);
        }
    }
}
