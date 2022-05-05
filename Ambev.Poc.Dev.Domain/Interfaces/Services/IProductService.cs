using Ambev.Poc.Dev.Domain.Models.Product.Request;
using Ambev.Poc.Dev.Domain.Models.Product.Response;

namespace Ambev.Poc.Dev.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductResponseModel> GetProductId(int productId);
        Task<IEnumerable<ProductResponseModel>> GetAllProduct();
        Task<bool> CreateProduct(ProductRequestModel productModel);
        Task<ProductResponseModel> UpdateProduct(ProductRequestModel productModel);
        Task<bool> DeleteProduct(int productId);
    }
}
