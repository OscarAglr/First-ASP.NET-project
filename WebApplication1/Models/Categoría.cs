using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Categoría
{
    public int IdCategoría { get; set; }

    public string NombreCategoría { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
