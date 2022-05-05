using Ambev.Poc.Dev.Domain.Interfaces.Services;
using Ambev.Poc.Dev.Domain.Models.OrderProduct.Request;
using Ambev.Poc.Dev.Domain.Models.OrderProduct.Response;
using Ambev.Poc.Dev.Domain.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmBev.Poc.Dev.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ApiControlleBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseBaseModel<OrderProductResponse>>> Get() => GetResponse(await _orderService.GetAllOrders());

        [HttpGet("{orderId}")]
        public async Task<ActionResult<ResponseBaseModel<OrderProductResponse>>> GetById(int orderId) => GetResponse(await _orderService.GetOrderById(orderId));

        [HttpPost]
        public async Task<ActionResult<ResponseBaseModel<int>>> Post([FromBody] OrderProductRequestModel orderModel) => GetResponse(await _orderService.CreateOrderProduct(orderModel));

    }
}
