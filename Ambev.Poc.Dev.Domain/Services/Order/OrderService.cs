
using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Exceptions;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Interfaces.Services;
using Ambev.Poc.Dev.Domain.Models.OrderProduct.Request;

namespace Ambev.Poc.Dev.Domain.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public async Task<int> CreateOrderProduct(OrderProductRequestModel orderRequest)
        {
            var productEntity = await _productRepository.GetProducById(orderRequest.ProductId);
            if (productEntity == null)
            {
                throw new BadRequestException("Product not found");
            }

            var customerEntity = await _customerRepository.GetCustomerById(orderRequest.CustomerId);
            if (customerEntity == null)
            {
                throw new BadRequestException("Customer not found");
            }

            var orderProductEntity = new OrderProductEntity(orderRequest, productEntity);

            if (orderProductEntity.TotalOrder != orderRequest.TotalOrder)
            {
                throw new BadRequestException("Diff value total order");
            }

            var result = await _orderRepository.CreateProduct(orderProductEntity);

            return result;
        }
    }
}
