using Ambev.Poc.Dev.Domain.Entities;

namespace Ambev.Poc.Dev.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<int> CreateProduct(OrderProductEntity entity);
    }
}
