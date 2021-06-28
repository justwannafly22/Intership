using AutoMapper;
using Intership.Data.Abstracts;
using Intership.Data.Parameters;
using Intership.Models.RequestModels.Product;
using Intership.Models.RequestModels.Repair;
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
        private readonly IRepairRepository _repairRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IRepairRepository repairRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _repairRepository = repairRepository;
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
        public async Task DeleteProductAsync(AddProductModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _productRepository.DeleteProductAsync(_mapper.Map<ProductParameter>(model));
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
            var product = await _productRepository.GetProductAsync(productId, trackChanges: true);

            return _mapper.Map<IEnumerable<RepairResponseModel>>(product.Repairs); //need to check this;
        }

        /// <summary>
        /// Get a single repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<RepairResponseModel> GetRepairByProduct(Guid productId, Guid repairId)
        {
            var product = await _productRepository.GetProductAsync(productId, trackChanges: true);

            return _mapper.Map<RepairResponseModel>(product.Repairs.Where(r => r.Id.Equals(repairId)).SingleOrDefault());
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateProductAsync(UpdateProductModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await _productRepository.UpdateProductAsync(_mapper.Map<ProductParameter>(model));
        }

        /// <summary>
        /// Create repair for the product
        /// </summary>
        /// <param name="model"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Guid> CreateRepairForProductAsync(AddRepairModel model, Guid productId)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var product = await _productRepository.GetProductAsync(productId, trackChanges: true);
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var addedRepairId = await _repairRepository.CreateRepairAsync(_mapper.Map<RepairParameter>(model));

            product.Repairs.Add(_repairRepository.GetRepairAsync(addedRepairId, trackChanges: false).Result);

            return addedRepairId;
        }

        /// <summary>
        /// Update a repair for the product
        /// </summary>
        /// <param name="model"></param>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateRepairForProductAsync(UpdateRepairModel model, Guid productId, Guid repairId)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var product = await _productRepository.GetProductAsync(productId, trackChanges: true);
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var repair = product.Repairs.Where(r => r.Id.Equals(repairId)).SingleOrDefault();

            repair.Name = model.Name;

            return await _repairRepository.UpdateRepairAsync(_mapper.Map<RepairParameter>(model));
        }

        /// <summary>
        /// Delete a repair for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="repairId"></param>
        /// <returns></returns>
        public async Task DeleteRepairForProductAsync(Guid productId, Guid repairId)
        {
            var product = await _productRepository.GetProductAsync(productId, trackChanges: true);
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var repair = product.Repairs.Where(r => r.Id.Equals(repairId)).SingleOrDefault();
            if (repair == null)
            {
                throw new ArgumentNullException(nameof(repair));
            }

            product.Repairs.Remove(repair);
        }
    }
}
