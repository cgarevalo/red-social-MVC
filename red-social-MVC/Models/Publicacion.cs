using System;
using System.Collections.Generic;

namespace red_social_MVC.Models;

public partial class Publicacion
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public DateTime Fecha { get; set; }

    public int IdTipoPublicacion { get; set; }

    public string? Texto { get; set; }

    public int? IdPublicacionCompartida { get; set; }

    public string? ImagenPublicacion { get; set; }

    public string? VideoPublicacion { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Publicacion? IdPublicacionCompartidaNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Publicacion> InverseIdPublicacionCompartidaNavigation { get; set; } = new List<Publicacion>();

    public virtual ICollection<Reaccion> Reacciones { get; set; } = new List<Reaccion>();
}
