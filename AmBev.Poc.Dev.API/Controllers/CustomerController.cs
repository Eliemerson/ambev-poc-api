using Ambev.Poc.Dev.Domain.Interfaces.Services;
using Ambev.Poc.Dev.Domain.Models.Customer.Request;
using Ambev.Poc.Dev.Domain.Models.Customer.Response;
using Ambev.Poc.Dev.Domain.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmBev.Poc.Dev.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerController : ApiControlleBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseBaseModel<CustomerResponseModel>>> Get() => GetResponse(await _customerService.GetAllCustomer());

        [HttpGet("{customerId}")]
        public async Task<ActionResult<ResponseBaseModel<bool>>> GetById(int customerId) => GetResponse(await _customerService.GetCustomerId(customerId));

        [HttpPost]
        public async Task<ActionResult<ResponseBaseModel<bool>>> Post([FromBody] CustomerCreateModel customerModel) => GetResponse(await _customerService.CreateCustomer(customerModel));

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseBaseModel<CustomerResponseModel>>> Updated([FromBody] CustomerUpdateModel customerModel) => GetResponse(await _customerService.UpdateCustomer(customerModel));

        [HttpDelete("{customerId}")]
        public async Task<ActionResult<ResponseBaseModel<bool>>> Delete(int customerId) => GetResponse(await _customerService.DeleteCustomer(customerId));
    }
}
