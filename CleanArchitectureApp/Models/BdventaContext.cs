using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureApp.Models;

public partial class BdventaContext : DbContext
{
    public BdventaContext()
    {
    }

    public BdventaContext(DbContextOptions<BdventaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Pagina> Paginas { get; set; }

    public virtual DbSet<PaginaTipoUsuario> PaginaTipoUsuarios { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-07LAHVE;database=BDVenta;Integrated Security=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Iidcategoria);

            entity.Property(e => e.Iidcategoria).HasColumnName("IIDCATEGORIA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.Iiddetalleventa).HasName("PK_DetalleVentaReserva");

            entity.Property(e => e.Iiddetalleventa).HasColumnName("IIDDETALLEVENTA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Iidproducto).HasColumnName("IIDPRODUCTO");
            entity.Property(e => e.Iidventa).HasColumnName("IIDVENTA");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL");

            entity.HasOne(d => d.IidproductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Iidproducto)
                .HasConstraintName("FK_DetalleVentaReserva_Producto");

            entity.HasOne(d => d.IidventaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Iidventa)
                .HasConstraintName("FK__DetalleVe__IIDRE__3B75D760");
        });

        modelBuilder.Entity<Pagina>(entity =>
        {
            entity.HasKey(e => e.Iidpagina).HasName("PK_Paginas");

            entity.ToTable("Pagina");

            entity.Property(e => e.Iidpagina).HasColumnName("IIDPAGINA");
            entity.Property(e => e.Accion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ACCION");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MENSAJE");
        });

        modelBuilder.Entity<PaginaTipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Iidpaginatipousuario);

            entity.ToTable("PaginaTipoUsuario");

            entity.Property(e => e.Iidpaginatipousuario).HasColumnName("IIDPAGINATIPOUSUARIO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Iidpagina).HasColumnName("IIDPAGINA");
            entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");

            entity.HasOne(d => d.IidpaginaNavigation).WithMany(p => p.PaginaTipoUsuarios)
                .HasForeignKey(d => d.Iidpagina)
                .HasConstraintName("FK__PaginaTip__IIDPA__267ABA7A");

            entity.HasOne(d => d.IidtipousuarioNavigation).WithMany(p => p.PaginaTipoUsuarios)
                .HasForeignKey(d => d.Iidtipousuario)
                .HasConstraintName("FK__PaginaTip__IIDTI__276EDEB3");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Iidpersona);

            entity.ToTable("Persona");

            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");
            entity.Property(e => e.Apmaterno)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("APMATERNO");
            entity.Property(e => e.Appaterno)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("APPATERNO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Btieneusuario).HasColumnName("BTIENEUSUARIO");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Fechanacimiento)
                .HasColumnType("date")
                .HasColumnName("FECHANACIMIENTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Iidproducto);

            entity.ToTable("Producto");

            entity.Property(e => e.Iidproducto).HasColumnName("IIDPRODUCTO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Iidcategoria).HasColumnName("IIDCATEGORIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Stock).HasColumnName("STOCK");

            entity.HasOne(d => d.IidcategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Iidcategoria)
                .HasConstraintName("FK_Producto_Categoria");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.Iidsede);

            entity.ToTable("Sede");

            entity.Property(e => e.Iidsede).HasColumnName("IIDSEDE");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Iidtipousuario);

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Iidusuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Contra)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTRA");
            entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");
            entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");
            entity.Property(e => e.Nombreusuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREUSUARIO");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Iidpersona)
                .HasConstraintName("FK_Usuario_Persona");

            entity.HasOne(d => d.IidtipousuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Iidtipousuario)
                .HasConstraintName("FK__Usuario__IIDTIPO__1CF15040");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.Iidventa).HasName("PK_Reserva");

            entity.Property(e => e.Iidventa).HasColumnName("IIDVENTA");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Fechaventa)
                .HasColumnType("datetime")
                .HasColumnName("FECHAVENTA");
            entity.Property(e => e.Iidsede).HasColumnName("IIDSEDE");
            entity.Property(e => e.Iidusuariovender).HasColumnName("IIDUSUARIOVENDER");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IidsedeNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Iidsede)
                .HasConstraintName("FK_Reserva_Sede");

            entity.HasOne(d => d.IidusuariovenderNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Iidusuariovender)
                .HasConstraintName("FK_Venta_Usuario1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
