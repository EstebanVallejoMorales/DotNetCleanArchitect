using System;
using System.Collections.Generic;

namespace CleanArchitectureApp.Models;

public partial class Categorium
{
    public int Iidcategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
