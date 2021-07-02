using AutoMapper;
using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Models.RequestModels.Product;
using Intership.Models.ResponseModels;
using Intership.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateProductAsync(AddProductModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _productRepository.CreateProductAsync(_mapper.Map<ProductParameter>(model));
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        /// <summary>
        /// Returns a single product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductResponseModel> GetProductAsync(Guid id) =>
            _mapper.Map<ProductResponseModel>(await _productRepository.GetProductAsync(id, trackChanges: true));

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductResponseModel>> GetProductsAsync() =>
            _mapper.Map<IEnumerable<ProductResponseModel>>(await _productRepository.GetProductsAsync(trackChanges: false));

        /// <summary>
        /// Check for existing product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _productRepository.GetProductAsync(id, trackChanges: false) != null;

        /// <summary>
        /// Returns a repairs for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RepairResponseModel>> GetRepairsByProduct(Guid productId)
        {
            var product = await _productRepository.GetProductWithRepairsAsync(productId, trackChanges: false);

            return _mapper.Map<IEnumerable<RepairResponseModel>>(product.ReplacedParts.Select(r => r.Repair));
        }

        /// <summary>
        /// Get a single repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<RepairResponseModel> GetRepairByProduct(Guid productId, Guid repairId)
        {
            var product = await _productRepository.GetProductWithRepairsAsync(productId, trackChanges: true);

            return _mapper.Map<RepairResponseModel>(product.ReplacedParts.Where(r => r.RepairId.Equals(repairId)).SingleOrDefault());
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateProductAsync(Guid id, UpdateProductModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            
            return await _productRepository.UpdateProductAsync(id, _mapper.Map<ProductParameter>(model));
        }

        /// <summary>
        /// Check for existing repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<bool> IsExistRepair(Guid productId, Guid repairId)
        {
            var product = await _productRepository.GetProductAsync(productId, trackChanges: false);

            return product.ReplacedParts.Where(r => r.RepairId.Equals(repairId)).SingleOrDefault() != null;
        }
    }
}
