using AutoMapper;
using Intership.Abstracts;
using Intership.Abstracts.Services;
using Intership.DTO.Product;
using Intership.Filters;
using Intership.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsEntity = await _productService.GetProductsAsync();

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsEntity);

            return Ok(productsDto);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var productEntity = await _productService.GetProductAsync(productId);
            if (productEntity == null)
            {
                _logger.LogInfo($"Product with id: {productId} doesn`t exist in the database.");
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(productEntity);
            
            return Ok(productDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreateDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);

            await _productService.CreateProductAsync(productEntity);

            return Created($"api/v1/{productEntity.Id}", new { productId = productEntity.Id });
        }

        [HttpDelete("{productId}")]
        [ServiceFilter(typeof(ValidateProductExistAttribute))]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var productEntity = HttpContext.Items["product"] as Product;

            await _productService.DeleteProductAsync(productEntity);
            
            return NoContent();
        }
        
        [HttpPut("{productId}")]
        [ServiceFilter(typeof(ValidateProductExistAttribute))]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] ProductForUpdateDto productDto)
        {
            var productEntity = HttpContext.Items["product"] as Product;

            _mapper.Map(productDto, productEntity);

            await _productService.UpdateProductAsync(productEntity);

            return NoContent();
        }
    }
}
