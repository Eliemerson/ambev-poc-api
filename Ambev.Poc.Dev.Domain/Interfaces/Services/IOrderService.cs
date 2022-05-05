using Ambev.Poc.Dev.Domain.Models.OrderProduct.Request;
using Ambev.Poc.Dev.Domain.Models.OrderProduct.Response;

namespace Ambev.Poc.Dev.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderProductResponse>> GetAllOrders();
        Task<OrderProductResponse> GetOrderById(int orderId);
        Task<int> CreateOrderProduct(OrderProductRequestModel orderRequest);
    }
}
