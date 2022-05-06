using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Exceptions;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Interfaces.Services;
using Ambev.Poc.Dev.Domain.Models.Customer.Request;
using Ambev.Poc.Dev.Domain.Models.Customer.Response;
using Ambev.Poc.Dev.Domain.Services.User;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ambev.Poc.Dev.Domain.Test.Services
{
    public class CustomerServiceTest
    {
        private Mock<ICustomerRepository> _customerRepositoryMock;

        private CustomerService Service;

        public CustomerServiceTest()
        {
            const MockBehavior behavior = MockBehavior.Strict;
            _customerRepositoryMock = new Mock<ICustomerRepository>(behavior);
        }

        private CustomerEntity MockCustomerEntity()
        {
            return new CustomerEntity(1)
            {
                Email = "teste@user.com",
                IsActive = true,
                Name = "Teste",
                LastName = "Ambev"
            };
        }

        private IEnumerable<CustomerResponseModel> MockCustomerResponseList()
        {
            return new List<CustomerResponseModel>() {
             new CustomerResponseModel()
                {
                    Email = "teste@user.com",
                    Name = "Teste",
                    LastName = "Ambev"
                },
             new CustomerResponseModel()
                {
                    Email = "teste@user.com",
                    Name = "Teste",
                    LastName = "Ambev"
                },
             new CustomerResponseModel()
                {
                    Email = "teste@user.com",
                    Name = "Teste",
                    LastName = "Ambev"
                }
            };
        }

        private IEnumerable<CustomerEntity> MockCustomerEntityList()
        {
            return new List<CustomerEntity>() {
             new CustomerEntity()
                {
                    Email = "teste@user.com",
                    Name = "Teste",
                    LastName = "Ambev"
                },
             new CustomerEntity()
                {
                    Email = "teste@user.com",
                    Name = "Teste",
                    LastName = "Ambev"
                },
             new CustomerEntity()
                {
                    Email = "teste@user.com",
                    Name = "Teste",
                    LastName = "Ambev"
                }
            };
        }

        [SetUp]
        public void Setup()
        {
            Service = new CustomerService(_customerRepositoryMock.Object);
        }

        [Test]
        public void Should_Return_Only_One_Customer_By_Id()
        {
            var customerId = 1;

            var mockResult = MockCustomerEntity();

            _customerRepositoryMock.Setup(x => x.GetCustomerById(It.IsAny<int>())).ReturnsAsync(mockResult);

            var result = Service.GetCustomerId(customerId);

            Assert.AreEqual(result.Result.Name, mockResult.Name);
            Assert.AreEqual(result.Result.Email, mockResult.Email);
            Assert.AreEqual(result.Result.LastName, mockResult.LastName);
            Assert.AreEqual(result.Result.Id, mockResult.Id);
        }

        [Test]
        public void Should_Return_Null()
        {
            var customerId = 1;


            _customerRepositoryMock.Setup(x => x.GetCustomerById(It.IsAny<int>())).Returns(Task.FromResult<CustomerEntity>(null));

            var result = Service.GetCustomerId(customerId);

            Assert.AreEqual(result.Result, null);
        }


        [Test]
        public void Should_Return_List_Same_Count()
        {

            var mockCustomerResoponse = MockCustomerResponseList();
            _customerRepositoryMock.Setup(x => x.GetAllCustomers()).ReturnsAsync(mockCustomerResoponse);

            var result = Service.GetAllCustomer();

            Assert.AreEqual(result.Result.Count(), mockCustomerResoponse.Count());
        }

        [Test]
        public void Should_Return_Error_Email_Does_Not_Exist()
        {
            var customerRequest = new CustomerCreateModel()
            {
                Email = "teste@ambev.com",
                Name = "Ambev",
                LastName = "Tech"
            };

            var mockCustomerListEntity = MockCustomerEntityList();

            _customerRepositoryMock.Setup(x => x.GetCustomerSameEmail(It.IsAny<string>()))
                .ReturnsAsync(MockCustomerEntityList());

            Assert.ThrowsAsync<ValidationException>(async () => await Service.CreateCustomer(customerRequest));
        }

        [Test]
        public void Should_Return_Created_Customer()
        {
            var customerRequest = new CustomerCreateModel()
            {
                Email = "teste@ambev.com",
                Name = "Ambev",
                LastName = "Tech"
            };

            var newCustomerIdRetunerd = 8;

            var mockCustomerResoponse = MockCustomerResponseList();
            _customerRepositoryMock.Setup(x => x.GetCustomerSameEmail(It.IsAny<string>()))
                .ReturnsAsync(new List<CustomerEntity>());

            _customerRepositoryMock.Setup(x => x.CreateCustomer(It.IsAny<CustomerEntity>())).ReturnsAsync(newCustomerIdRetunerd);


            var result = Service.CreateCustomer(customerRequest);

            Assert.AreEqual(result.Result, newCustomerIdRetunerd);
        }


        [Test]
        public void Should_Return_Updated_Customer()
        {
            var customerRequest = new CustomerUpdateModel()
            {
                Id = 1,
                Name = "Ambev 2",
                LastName = "Tech 2"
            };


            var customerEntity = new CustomerEntity(1)
            {
                Name = "Ambev 2",
                LastName = "Tech 2"
            };

            var mockResult = MockCustomerEntity();

            _customerRepositoryMock.Setup(x => x.GetCustomerById(It.IsAny<int>())).ReturnsAsync(mockResult);

            _customerRepositoryMock.Setup(x => x.UpdateCustomer(It.IsAny<CustomerEntity>()))
                .ReturnsAsync(customerEntity);



            var result = Service.UpdateCustomer(customerRequest);

            Assert.AreEqual(result.Result.Id, customerRequest.Id);
            Assert.AreEqual(result.Result.Name, customerRequest.Name);
            Assert.AreEqual(result.Result.LastName, customerRequest.LastName);
        }

        [Test]
        public void Should_Return_Bad_Exception_Customer()
        {
            var customerRequest = new CustomerUpdateModel()
            {
                Id = 1,
                Name = "Ambev 2",
                LastName = "Tech 2"
            };


            var customerEntity = new CustomerEntity(1)
            {
                Name = "Ambev 2",
                LastName = "Tech 2"
            };

            var mockResult = MockCustomerEntity();

            _customerRepositoryMock.Setup(x => x.GetCustomerById(It.IsAny<int>())).Returns(Task.FromResult<CustomerEntity>(null));


            var result = Service.UpdateCustomer(customerRequest);

            Assert.ThrowsAsync<BadRequestException>(async () => await Service.UpdateCustomer(customerRequest));
        }
    }
}
