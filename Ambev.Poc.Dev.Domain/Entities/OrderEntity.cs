namespace Ambev.Poc.Dev.Domain.Entities
{
    public class OrderEntity : EntityBase
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public decimal TotalOrder { get; set; }
        public decimal UnitaryValueProduct { get; set; }
        public int Amount { get; set; }
    }
}
