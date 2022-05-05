using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Exceptions;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Interfaces.Services;
using Ambev.Poc.Dev.Domain.Models.Customer;
using Ambev.Poc.Dev.Domain.Models.Customer.Request;
using System.ComponentModel.DataAnnotations;

namespace Ambev.Poc.Dev.Domain.Services.User
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerModel> GetCustomerId(int customerId)
        {
            var customerEntity = await _customerRepository.GetCustomerById(customerId);

            if (customerEntity == null)
            {
                return null;
            }

            return new CustomerModel(customerEntity);
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomer()
        {
            var customerEntity = await _customerRepository.GetAllCustomers();

            return customerEntity;
        }

        public async Task<bool> CreateCustomer(CustomerModel customer)
        {
            var anyEmail = await _customerRepository.GetCustomerSameEmail(customer.Email);

            if (anyEmail.Any())
            {
                throw new ValidationException("Email");
            }

            var customerEntity = new CustomerEntity(customer);

            var result = await _customerRepository.CreateCostomer(customerEntity);

            return result;
        }

        public async Task<CustomerModel> UpdateCustomer(CustomerUpdateModel customer)
        {
            var customerEntity = await _customerRepository.GetCustomerById(customer.Id);

            if (customerEntity == null)
            {
                throw new BadRequestException("Customer not found");
            }

            var result = await _customerRepository.UpdateCustomer(customerEntity.UpdateCustomer(customer));

            return new CustomerModel(result);
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var customerEntity = await _customerRepository.GetCustomerById(customerId);

            if (customerEntity == null)
            {
                throw new BadRequestException("Customer not found");
            }
            var result = await _customerRepository.DeleteCustomer(customerEntity.Id);

            return result;
        }
    }
}
