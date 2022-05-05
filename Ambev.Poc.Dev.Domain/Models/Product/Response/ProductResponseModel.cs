using Ambev.Poc.Dev.Domain.Entities;

namespace Ambev.Poc.Dev.Domain.Models.Product.Response
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public ProductResponseModel()
        {

        }
        public ProductResponseModel(ProductEntity productEntity)
        {
            Id = productEntity.Id;
            Name = productEntity.Name;
            Sku = productEntity.Sku;
            Price = productEntity.Price;
            Category = productEntity.Category;

        }
    }
}
