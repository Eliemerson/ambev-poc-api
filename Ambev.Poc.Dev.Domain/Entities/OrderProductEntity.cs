using Ambev.Poc.Dev.Domain.Models.OrderProduct.Request;

namespace Ambev.Poc.Dev.Domain.Entities
{
    public class OrderProductEntity : EntityBase
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalOrder { get; set; }
        public int Amount { get; set; }

        public OrderProductEntity(OrderProductRequestModel orderModel, ProductEntity productEntity)
        {
            ProductId = orderModel.ProductId;
            CustomerId = orderModel.CustomerId;
            TotalOrder = orderModel.Amount * productEntity.Price;
            Amount = orderModel.Amount;
        }
    }
}
