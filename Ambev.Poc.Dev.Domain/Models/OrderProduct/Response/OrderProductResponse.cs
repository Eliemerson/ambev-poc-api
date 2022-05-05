using Ambev.Poc.Dev.Domain.Entities;

namespace Ambev.Poc.Dev.Domain.Models.OrderProduct.Response
{
    public class OrderProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalOrder { get; set; }
        public int Amount { get; set; }
    }
}
