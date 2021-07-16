﻿using Intership.Models.RequestModels.Product;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        /// Returns all products
        /// </summary>
        /// <response code="200">Success. Products were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<ProductResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync().ConfigureAwait(false);

            return Ok(products);
        }

        /// <summary>
        /// Returns a product
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Product model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Product with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ProductResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var product = await _productService.GetAsync(id).ConfigureAwait(false);

            if (product == null)
            {
                return NotFound(new BaseResponseModel($"Product with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            return Ok(product);
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Product model was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ProductResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProductModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedProduct = await _productService.CreateAsync(model).ConfigureAwait(false);

            return CreatedAtAction(nameof(Get), new { productId = addedProduct.Id }, addedProduct);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Product was deleted successfully</response>
        /// <response code="404">Product with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!await _productService.IsExist(id).ConfigureAwait(false))
            {
                return NotFound(new BaseResponseModel($"Product with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }
            
            await _productService.DeleteAsync(id).ConfigureAwait(false);

            return NoContent();
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <response code="200">Product was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Product with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductModel model)
        {
            if (!await _productService.IsExist(id).ConfigureAwait(false))
            {
                return NotFound(new BaseResponseModel($"Product with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var updatedProductId = await _productService.UpdateAsync(id, model).ConfigureAwait(false);

            return RedirectToAction(nameof(Get), new { id = updatedProductId });
        }

        /// <summary>
        /// Returns all repairs by product
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Products were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<RepairResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}/repairs")]
        public async Task<IActionResult> GetRepairsByProduct([FromRoute] Guid id)
        {
            if (!await _productService.IsExist(id).ConfigureAwait(false))
            {
                return NotFound(new BaseResponseModel($"Product with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            var repairs = await _productService.GetRepairsByProductAsync(id).ConfigureAwait(false);

            return Ok(repairs);
        }

        /// <summary>
        /// Get repair for the product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repairId"></param>
        /// <response code="200">Success. Product model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Product with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ProductResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}/repairs/{repairId}")]
        public async Task<IActionResult> GetRepair([FromRoute] Guid id, [FromRoute] Guid repairId)
        {
            if (!await _productService.IsRepairExist(id, repairId).ConfigureAwait(false))
            {
                return NotFound(new BaseResponseModel($"Product with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            var repair = await _productService.GetRepairByProductAsync(id, repairId).ConfigureAwait(false);

            return Ok(repair);
        }
    }
}
