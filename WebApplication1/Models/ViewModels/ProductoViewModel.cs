using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class ProductoViewModel
    {
        [Display(Name = "Nombre")]
        public string NombreProducto { get; set; }
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }
        public decimal Precio {  get; set; }
        public int Stock {  get; set; }
    }
}
