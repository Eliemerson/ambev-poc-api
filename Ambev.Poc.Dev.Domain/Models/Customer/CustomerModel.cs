using Ambev.Poc.Dev.Domain.Entities;
using System.Text.Json.Serialization;

namespace Ambev.Poc.Dev.Domain.Models.Customer
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public CustomerModel()
        {

        }
        public CustomerModel(CustomerEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            LastName = entity.LastName;
            Email = entity.Email;
        }
    }
}
