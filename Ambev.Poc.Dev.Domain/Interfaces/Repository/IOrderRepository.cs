using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Models.OrderProduct.Response;

namespace Ambev.Poc.Dev.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderProductResponse>> GetAllOrders();
        Task<OrderProductResponse> GetOrderById(int orderId);
        Task<int> CreateProduct(OrderProductEntity entity);
    }
}
