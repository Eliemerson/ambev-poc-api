namespace Ambev.Poc.Dev.Domain.Models.OrderProduct.Request
{
    public class OrderProductRequestModel
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalOrder { get; set; }
        public int Amount { get; set; }
    }
}
