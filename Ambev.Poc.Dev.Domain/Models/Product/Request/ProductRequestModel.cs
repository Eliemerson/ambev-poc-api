namespace Ambev.Poc.Dev.Domain.Models.Product.Request
{
    public class ProductRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
