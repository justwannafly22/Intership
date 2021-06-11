using AutoMapper;
using Intership.Abstracts;
using Intership.Abstracts.Logic;
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
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductLogic _productLogic;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductController(IProductLogic productLogic, ILoggerManager logger, IMapper mapper)
        {
            _productLogic = productLogic;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsEntity = await _productLogic.GetProductsAsync();

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsEntity);

            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var productEntity = await _productLogic.GetProductAsync(id);
            if (productEntity == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn`t exist in the database.");
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

            await _productLogic.CreateProductAsync(productEntity);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateProductExistAttribute))]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var productEntity = HttpContext.Items["product"] as Product;

            await _productLogic.DeleteProductAsync(productEntity);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateProductExistAttribute))]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductForUpdateDto productDto)
        {
            var productEntity = HttpContext.Items["product"] as Product;

            _mapper.Map(productDto, productEntity);

            await _productLogic.UpdateProductAsync(productEntity);

            return NoContent();
        }
    }
}
