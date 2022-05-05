using System.ComponentModel.DataAnnotations;

namespace Ambev.Poc.Dev.Domain.Models.OrderProduct.Request
{
    public class OrderProductRequestModel
    {

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public decimal TotalOrder { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public int Amount { get; set; }
    }
}
