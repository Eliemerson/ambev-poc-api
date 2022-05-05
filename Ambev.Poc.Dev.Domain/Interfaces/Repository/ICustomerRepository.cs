using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Models.Customer;

namespace Ambev.Poc.Dev.Domain.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerEntity>> GetCustomerSameEmail(string email);
        Task<IEnumerable<CustomerModel>> GetAllCustomers();
        Task<CustomerEntity> GetCustomerById(int customerId);
        Task<bool> CreateCostomer(CustomerEntity entity);
        Task<CustomerEntity> UpdateCustomer(CustomerEntity customerEntity);
        Task<bool> DeleteCustomer(int customerId);
    }
}
