using System;
using System.Collections.Generic;

namespace TallerCinco.Models;

public partial class Tipo
{
    public int IdTipo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
