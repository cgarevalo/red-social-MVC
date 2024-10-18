using System;
using System.Collections.Generic;

namespace red_social_MVC.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? FotoPerfil { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Publicacion> Publicaciones { get; set; } = new List<Publicacion>();

    public virtual ICollection<Reaccion> Reacciones { get; set; } = new List<Reaccion>();
}
