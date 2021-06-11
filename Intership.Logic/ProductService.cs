using Intership.Abstracts.Logic;
using Intership.Abstracts.Repositories;
using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intership.Logic
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.CreateProductAsync(product);
        }

        public async Task DeleteProductAsync(Product product)
        {
            await _productRepository.DeleteProductAsync(product);
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            var product = await _productRepository.GetProductAsync(id, trackChanges: true);

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync(trackChanges: false);

            return products;
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }
    }
}
