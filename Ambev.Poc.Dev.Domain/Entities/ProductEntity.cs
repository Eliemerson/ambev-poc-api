using Ambev.Poc.Dev.Domain.Models.Product.Request;

namespace Ambev.Poc.Dev.Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }

        public ProductEntity()
        {

        }

        public ProductEntity(ProductCreateModel productModel)
        {
            Name = productModel.Name;
            Sku = productModel.Sku;
            Price = productModel.Price;
            Category = productModel.Category;
        }

        public ProductEntity UpdateProduct(ProductRequestModel productModel)
        {
            Name = productModel.Name;
            Sku = productModel.Sku;
            Price = productModel.Price;
            Category = productModel.Category;
            return this;
        }

        public ProductEntity(int id)
        {
            Id = id;    
        }
    }
}
