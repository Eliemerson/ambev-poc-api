namespace Ambev.Poc.Dev.Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
