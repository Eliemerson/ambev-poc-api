using Ambev.Poc.Dev.Domain.Interfaces.Services;
using Ambev.Poc.Dev.Domain.Models.Product.Request;
using Ambev.Poc.Dev.Domain.Models.Product.Response;
using Ambev.Poc.Dev.Domain.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmBev.Poc.Dev.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProductController : ApiControlleBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseBaseModel<ProductResponseModel>>> Get() => GetResponse(await _productService.GetAllProduct());

        [HttpGet("{productId}")]
        public async Task<ActionResult<ResponseBaseModel<bool>>> GetById(int productId) => GetResponse(await _productService.GetProductId(productId));

        [HttpPost]
        public async Task<ActionResult<ResponseBaseModel<bool>>> Post([FromBody] ProductRequestModel productModel) => GetResponse(await _productService.CreateProduct(productModel));

        [HttpPut("")]
        public async Task<ActionResult<ResponseBaseModel<ProductResponseModel>>> Updated([FromBody] ProductRequestModel productModel) => GetResponse(await _productService.UpdateProduct(productModel));

        [HttpDelete("{productId}")]
        public async Task<ActionResult<ResponseBaseModel<bool>>> Delete(int productId) => GetResponse(await _productService.DeleteProduct(productId));
    }
}
