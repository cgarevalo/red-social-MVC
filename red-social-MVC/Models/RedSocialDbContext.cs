using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace red_social_MVC.Models;

public partial class RedSocialDbContext : DbContext
{
    public RedSocialDbContext()
    {
    }

    public RedSocialDbContext(DbContextOptions<RedSocialDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Publicacion> Publicaciones { get; set; }

    public virtual DbSet<Reaccion> Reacciones { get; set; }

    public virtual DbSet<TipoPublicacion> TiposPublicaciones { get; set; }

    public virtual DbSet<TipoReaccion> TiposReacciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdPublicacion).HasColumnName("idPublicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Texto)
                .IsUnicode(false)
                .HasColumnName("texto");

            entity.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Publicacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Usuarios");
        });

        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Publicacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPublicacionCompartida).HasColumnName("idPublicacionCompartida");
            entity.Property(e => e.IdTipoPublicacion).HasColumnName("idTipoPublicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.ImagenPublicacion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("imagenPublicacion");
            entity.Property(e => e.Texto)
                .IsUnicode(false)
                .HasColumnName("texto");
            entity.Property(e => e.VideoPublicacion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("videoPublicacion");

            entity.HasOne(d => d.IdPublicacionCompartidaNavigation).WithMany(p => p.InverseIdPublicacionCompartidaNavigation)
                .HasForeignKey(d => d.IdPublicacionCompartida)
                .HasConstraintName("FK_Publicacion_Publicacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_usuarios");
        });

        modelBuilder.Entity<Reaccion>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPublicacion).HasColumnName("idPublicacion");
            entity.Property(e => e.IdTipoReaccion).HasColumnName("idTipoReaccion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Reacciones)
                .HasForeignKey(d => d.IdPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reacciones_Publicaciones");

            entity.HasOne(d => d.IdTipoReaccionNavigation).WithMany(p => p.Reacciones)
                .HasForeignKey(d => d.IdTipoReaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reacciones_TiposReacciones");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reacciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reacciones_Usuarios");
        });

        modelBuilder.Entity<TipoPublicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TipoPublicacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoReaccion>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
            entity.Property(e => e.FotoPerfil)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("fotoPerfil");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
