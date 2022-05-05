using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Models.Product.Response;

namespace Ambev.Poc.Dev.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductResponseModel>> GetAllProducts();
        Task<ProductEntity> GetProducById(int productId);
        Task<IEnumerable<ProductEntity>> GetProductBySku(string sku);
        Task<int> CreateProduct(ProductEntity entity);
        Task<ProductEntity> UpdateProduct(ProductEntity productEntity);
        Task<bool> DeleteProduct(int productId);
    }
}
