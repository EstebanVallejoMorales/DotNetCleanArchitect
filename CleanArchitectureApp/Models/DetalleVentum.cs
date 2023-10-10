using System;
using System.Collections.Generic;

namespace CleanArchitectureApp.Models;

public partial class DetalleVentum
{
    public int Iiddetalleventa { get; set; }

    public int? Iidventa { get; set; }

    public int? Iidproducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Producto? IidproductoNavigation { get; set; }

    public virtual Ventum? IidventaNavigation { get; set; }
}
