using Ambev.Poc.Dev.Domain.Models.Customer.Request;

namespace Ambev.Poc.Dev.Domain.Entities
{
    public class CustomerEntity : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public CustomerEntity()
        {

        }
        public CustomerEntity(CustomerCreateModel customerModel)
        {
            Name = customerModel.Name;
            LastName = customerModel.LastName;
            Email = customerModel.Email;
        }

        public CustomerEntity UpdateCustomer(CustomerUpdateModel customerModel)
        {
            Name = customerModel.Name;
            LastName = customerModel.LastName;
            return this;
        }
    }
}
