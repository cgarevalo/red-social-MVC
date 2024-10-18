using System;
using System.Collections.Generic;

namespace red_social_MVC.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public string Texto { get; set; } = null!;

    public int IdUsuario { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdPublicacion { get; set; }

    public virtual Publicacion IdPublicacionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
