using System.ComponentModel.DataAnnotations;

namespace Ambev.Poc.Dev.Domain.Models.Product.Request
{
    public class ProductRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public string Sku { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio.")]
        public string Category { get; set; }
    }
}
