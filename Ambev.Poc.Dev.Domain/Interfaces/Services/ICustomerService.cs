using Ambev.Poc.Dev.Domain.Models.Customer;
using Ambev.Poc.Dev.Domain.Models.Customer.Request;

namespace Ambev.Poc.Dev.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerModel> GetCustomerId(int customerId);
        Task<IEnumerable<CustomerModel>> GetAllCustomer();
        Task<bool> CreateCustomer(CustomerModel customer);
        Task<CustomerModel> UpdateCustomer(CustomerUpdateModel customer);
        Task<bool> DeleteCustomer(int customerId);
    }
}
