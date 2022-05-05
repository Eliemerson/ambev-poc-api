using Ambev.Poc.Dev.Domain.Models.OrderProduct.Request;

namespace Ambev.Poc.Dev.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<int> CreateOrderProduct(OrderProductRequestModel orderRequest);
    }
}
