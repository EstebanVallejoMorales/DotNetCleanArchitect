using System;
using System.Collections.Generic;

namespace CleanArchitectureApp.Models;

public partial class Ventum
{
    public int Iidventa { get; set; }

    public int? Iidusuariovender { get; set; }

    public int? Iidsede { get; set; }

    public DateTime? Fechaventa { get; set; }

    public int? Bhabilitado { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Sede? IidsedeNavigation { get; set; }

    public virtual Usuario? IidusuariovenderNavigation { get; set; }
}
