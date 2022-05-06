using System.ComponentModel.DataAnnotations;

namespace Ambev.Poc.Dev.Domain.Models.Product.Request
{
    public class ProductCreateModel
    {

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
