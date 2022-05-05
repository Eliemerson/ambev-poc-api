using System.ComponentModel.DataAnnotations;

namespace Ambev.Poc.Dev.Domain.Models.Customer.Request
{
    public class CustomerCreateModel
    {

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public string Email { get; set; }
    }
}
