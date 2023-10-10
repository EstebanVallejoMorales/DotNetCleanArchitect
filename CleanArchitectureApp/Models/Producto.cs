using System;
using System.Collections.Generic;

namespace CleanArchitectureApp.Models;

public partial class Producto
{
    public int Iidproducto { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public int? Iidcategoria { get; set; }

    public int? Bhabilitado { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Categorium? IidcategoriaNavigation { get; set; }
}
