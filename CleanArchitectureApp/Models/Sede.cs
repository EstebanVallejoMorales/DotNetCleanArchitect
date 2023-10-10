using System;
using System.Collections.Generic;

namespace CleanArchitectureApp.Models;

public partial class Sede
{
    public int Iidsede { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
