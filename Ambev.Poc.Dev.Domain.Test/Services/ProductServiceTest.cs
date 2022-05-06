using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Models.Product.Request;
using Ambev.Poc.Dev.Domain.Models.Product.Response;
using Ambev.Poc.Dev.Domain.Services.Product;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ambev.Poc.Dev.Domain.Test.Services
{
    public class ProductServiceTest
    {

        private Mock<IProductRepository> _productRepository;

        private ProductService Service;

        public ProductServiceTest()
        {
            const MockBehavior behavior = MockBehavior.Strict;
            _productRepository = new Mock<IProductRepository>(behavior);
        }


        private ProductEntity MockProductEntity()
        {
            return new ProductEntity(1)
            {
                Name = "Produto 01",
                Category = "A",
                IsActive = true,
                Price = 10.99m,
                Sku = "125"
            };
        }

        private IEnumerable<ProductResponseModel> MockProductResponseList()
        {
            return new List<ProductResponseModel>() {
             new ProductResponseModel()
                {
                  Name = "Produto 01",
                  Category = "A",
                  Price = 10.99m,
                  Sku = "001"
                },
             new ProductResponseModel()
                {
                  Name = "Produto 02",
                  Category = "A",
                  Price = 10.99m,
                  Sku = "003"
                },
             new ProductResponseModel()
                {
                  Name = "Produto 03",
                  Category = "A",
                  Price = 10.99m,
                  Sku = "003"
                }
            };
        }

        [SetUp]
        public void Setup()
        {
            Service = new ProductService(_productRepository.Object);
        }

        [Test]
        public void Should_Return_Only_One_Product_By_Id()
        {
            var id = 1;

            var mockResult = MockProductEntity();

            _productRepository.Setup(x => x.GetProducById(It.IsAny<int>())).ReturnsAsync(mockResult);

            var result = Service.GetProductId(id);

            Assert.AreEqual(result.Result.Name, mockResult.Name);
            Assert.AreEqual(result.Result.Price, mockResult.Price);
            Assert.AreEqual(result.Result.Id, mockResult.Id);
        }

        [Test]
        public void Should_Return_Null()
        {
            var id = 1;


            _productRepository.Setup(x => x.GetProducById(It.IsAny<int>())).Returns(Task.FromResult<ProductEntity>(null));

            var result = Service.GetProductId(id);

            Assert.AreEqual(result.Result, null);
        }

        [Test]
        public void Should_Return_List_Same_Count()
        {

            var mockProductResoponse = MockProductResponseList();
            _productRepository.Setup(x => x.GetAllProducts()).ReturnsAsync(mockProductResoponse);

            var result = Service.GetAllProduct();

            Assert.AreEqual(result.Result.Count(), mockProductResoponse.Count());
        }

        [Test]
        public void Should_Return_Error_Sku_Exist()
        {
            var productRequest = new ProductCreateModel()
            {
                Sku = "125",
                Category = "B",
                Name = "Teste",
                Price = 10
            };

            var mockProductEntity = MockProductEntity();

            _productRepository.Setup(x => x.GetProductBySku(It.IsAny<string>()))
                .ReturnsAsync(new List<ProductEntity>() { mockProductEntity });

            Assert.ThrowsAsync<ValidationException>(async () => await Service.CreateProduct(productRequest));
        }

        [Test]
        public void Should_Return_Created_Product()
        {
            var productRequest = new ProductCreateModel()
            {
                Sku = "125",
                Category = "B",
                Name = "Teste",
                Price = 10
            };

            var mockProductEntity = MockProductEntity();

            var id = 10;

            _productRepository.Setup(x => x.GetProductBySku(It.IsAny<string>()))
                .ReturnsAsync(new List<ProductEntity>());

            _productRepository.Setup(x => x.CreateProduct(It.IsAny<ProductEntity>()))
                .ReturnsAsync(id);

            var result = Service.CreateProduct(productRequest);
            Assert.AreEqual(result.Result, id);
        }


        [Test]
        public void Should_Return_Updated_Product()
        {
            var productRequest = new ProductRequestModel()
            {
                Sku = "125",
                Category = "B",
                Name = "Teste 2",
                Price = 10,
                Id = 1
            };

            var mockProductEntity = MockProductEntity();


            _productRepository.Setup(x => x.GetProducById(It.IsAny<int>()))
                .ReturnsAsync(mockProductEntity);

            var productAfterUpdate = new ProductEntity(1)
            {
                Sku = "125",
                Category = "B",
                Name = "Teste 2",
                Price = 10
            };


            _productRepository.Setup(x => x.UpdateProduct(It.IsAny<ProductEntity>()))
                .ReturnsAsync(productAfterUpdate);



            var result = Service.UpdateProduct(productRequest);
            Assert.AreEqual(result.Result.Sku, productAfterUpdate.Sku);
            Assert.AreEqual(result.Result.Name, productAfterUpdate.Name);
        }
    }
}
