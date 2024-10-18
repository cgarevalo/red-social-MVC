using System;
using System.Collections.Generic;

namespace red_social_MVC.Models;

public partial class Reaccion
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdPublicacion { get; set; }

    public DateTime Fecha { get; set; }

    public int IdTipoReaccion { get; set; }

    public virtual Publicacion IdPublicacionNavigation { get; set; } = null!;

    public virtual TipoReaccion IdTipoReaccionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
