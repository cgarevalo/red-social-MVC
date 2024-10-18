using System;
using System.Collections.Generic;

namespace red_social_MVC.Models;

public partial class TipoReaccion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Reaccion> Reacciones { get; set; } = new List<Reaccion>();
}
