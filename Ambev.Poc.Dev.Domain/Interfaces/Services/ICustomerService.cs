using Ambev.Poc.Dev.Domain.Models.Customer.Response;
using Ambev.Poc.Dev.Domain.Models.Customer.Request;

namespace Ambev.Poc.Dev.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerResponseModel> GetCustomerId(int customerId);
        Task<IEnumerable<CustomerResponseModel>> GetAllCustomer();
        Task<int> CreateCustomer(CustomerCreateModel customer);
        Task<CustomerResponseModel> UpdateCustomer(CustomerUpdateModel customer);
        Task<bool> DeleteCustomer(int customerId);
    }
}
