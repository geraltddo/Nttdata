using System;
using Common;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Data
{
    public partial class NttDataContext : DbContext, IDbContext
    {
        public NttDataContext()
        {
        }

        public NttDataContext(DbContextOptions<NttDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Movimiento> Movimiento { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        private readonly IConfiguration _configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Nttdata"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodigoCliente)
                    .HasName("PK__Cliente__6B8A31AD4E1FFFA0");

                entity.Property(e => e.CodigoCliente).HasColumnName("codigoCliente");

                entity.Property(e => e.Clave)
                    .HasColumnName("clave")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.CodigoPersona).HasColumnName("codigoPersona");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.HasOne(d => d.CodigoPersonaNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.CodigoPersona)
                    .HasConstraintName("FK__Cliente__codigoP__1273C1CD");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.CodigoCuenta)
                    .HasName("PK__Cuenta__EB71ECB0F142B18E");

                entity.Property(e => e.CodigoCuenta).HasColumnName("codigoCuenta");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.NumeroCuenta)
                    .HasColumnName("numeroCuenta")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoInicial)
                    .HasColumnName("saldoInicial")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoCuenta)
                    .HasColumnName("tipoCuenta")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.CodigoMovimiento)
                    .HasName("PK__Movimien__CEF5FBC4CB268652");

                entity.Property(e => e.CodigoMovimiento).HasColumnName("codigoMovimiento");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoMovimiento)
                    .HasColumnName("tipoMovimiento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.CodigoPersona)
                    .HasName("PK__Persona__4F53D430977CBB29");

                entity.Property(e => e.CodigoPersona).HasColumnName("codigoPersona");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Genero)
                    .HasColumnName("genero")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasColumnName("identificacion")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
