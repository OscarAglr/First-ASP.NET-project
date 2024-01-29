using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public decimal Precio { get; set; }

    public int? Stock { get; set; }

    public int? IdCategoría { get; set; }

    public virtual Categoría? IdCategoríaNavigation { get; set; }
}
