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
    /// <summary>
    /// Product logic implementation
    /// </summary>
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
        public async Task<ProductResponseModel> CreateAsync(AddProductModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var addedProduct = await _productRepository.CreateAsync(_mapper.Map<ProductParameter>(model));

            return _mapper.Map<ProductResponseModel>(addedProduct);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Returns a single product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductResponseModel> GetAsync(Guid id) =>
            _mapper.Map<ProductResponseModel>(await _productRepository.GetAsync(id));

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductResponseModel>> GetAllAsync() =>
            _mapper.Map<List<ProductResponseModel>>(await _productRepository.GetAllAsync());

        /// <summary>
        /// Check for existing product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Guid id) =>
            await _productRepository.GetAsync(id) != null;

        /// <summary>
        /// Returns a repairs for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<List<RepairResponseModel>> GetRepairsByProductAsync(Guid productId)
        {
            var product = await _productRepository.GetWithRepairsAsync(productId);

            return _mapper.Map<List<RepairResponseModel>>(product.ReplacedParts.Select(r => r.Repair));
        }

        /// <summary>
        /// Get a single repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<RepairResponseModel> GetRepairByProductAsync(Guid productId, Guid repairId)
        {
            var product = await _productRepository.GetWithRepairsAsync(productId);

            return _mapper.Map<RepairResponseModel>(product.ReplacedParts.Where(r => r.RepairId.Equals(repairId)).SingleOrDefault());
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateAsync(Guid id, UpdateProductModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            
            return await _productRepository.UpdateAsync(id, _mapper.Map<ProductParameter>(model));
        }

        /// <summary>
        /// Check for existing repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<bool> IsRepairExist(Guid productId, Guid repairId)
        {
            var product = await _productRepository.GetAsync(productId);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            return product.ReplacedParts.Where(r => r.RepairId.Equals(repairId)).SingleOrDefault() != null;
        }
    }
}
