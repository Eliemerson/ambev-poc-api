using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Exceptions;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Interfaces.Services;
using Ambev.Poc.Dev.Domain.Models.Product.Request;
using Ambev.Poc.Dev.Domain.Models.Product.Response;
using System.ComponentModel.DataAnnotations;

namespace Ambev.Poc.Dev.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProduct()
        {

            var productModel = await _productRepository.GetAllProducts();

            return productModel;
        }

        public async Task<ProductResponseModel> GetProductId(int productId)
        {
            var productEntity = await _productRepository.GetProducById(productId);

            if (productEntity == null)
            {
                return null;
            }

            return new ProductResponseModel(productEntity);
        }


        public async Task<int> CreateProduct(ProductRequestModel productModel)
        {
            var anySky = await _productRepository.GetProductBySku(productModel.Sku);

            if (anySky.Any())
            {
                throw new ValidationException("Sku");
            }

            var productEntity = new ProductEntity(productModel);

            var result = await _productRepository.CreateProduct(productEntity);

            return result;
        }

        public async Task<ProductResponseModel> UpdateProduct(ProductRequestModel productModel)
        {
            var productEntity = await _productRepository.GetProducById(productModel.Id);

            if (productEntity == null)
            {
                throw new BadRequestException("Product not found");
            }
            var result = await _productRepository.UpdateProduct(productEntity.UpdateProduct(productModel));

            return new ProductResponseModel(result);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var productEntity = await _productRepository.GetProducById(productId);

            if (productEntity == null)
            {
                throw new BadRequestException("Product not found");
            }

            var result = await _productRepository.DeleteProduct(productEntity.Id);

            return result;
        }
    }
}
