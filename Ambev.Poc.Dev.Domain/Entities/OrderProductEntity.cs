namespace Ambev.Poc.Dev.Domain.Entities
{
    public class OrderProductEntity : EntityBase
    {
        public int ProductId { get; set; }
        public int CostomerId { get; set; }
        public decimal TotalOrder { get; set; }
        public int Amount { get; set; }
    }
}
