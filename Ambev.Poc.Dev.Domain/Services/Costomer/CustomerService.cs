using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Exceptions;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Interfaces.Services;
using Ambev.Poc.Dev.Domain.Models.Customer.Response;
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

        public async Task<CustomerResponseModel> GetCustomerId(int customerId)
        {
            var customerEntity = await _customerRepository.GetCustomerById(customerId);

            if (customerEntity == null)
            {
                return null;
            }

            return new CustomerResponseModel(customerEntity);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomer()
        {
            var customerEntity = await _customerRepository.GetAllCustomers();

            return customerEntity;
        }

        public async Task<int> CreateCustomer(CustomerCreateModel customer)
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

        public async Task<CustomerResponseModel> UpdateCustomer(CustomerUpdateModel customer)
        {
            var customerEntity = await _customerRepository.GetCustomerById(customer.Id);

            if (customerEntity == null)
            {
                throw new BadRequestException("Customer not found");
            }

            var result = await _customerRepository.UpdateCustomer(customerEntity.UpdateCustomer(customer));

            return new CustomerResponseModel(result);
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
