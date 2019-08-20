using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NuevoComienzo.Models
{
    public partial class FundacionUnNuevoComienzoContext : DbContext
    {
        public FundacionUnNuevoComienzoContext()
        {
        }

        public FundacionUnNuevoComienzoContext(DbContextOptions<FundacionUnNuevoComienzoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anotacion> Anotacion { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Identificador> Identificador { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Relacion> Relacion { get; set; }
        public virtual DbSet<TipoIdentificador> TipoIdentificador { get; set; }
        public virtual DbSet<TipoPersona> TipoPersona { get; set; }

        // Unable to generate entity type for table 'dbo.Relacion_Persona'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Distelec'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=FundacionUnNuevoComienzo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Anotacion>(entity =>
            {
                entity.Property(e => e.AnotacionId).HasColumnName("AnotacionID");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Canton>(entity =>
            {
                entity.Property(e => e.CantonId)
                    .HasColumnName("CantonID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Canton)
                    .HasForeignKey(d => d.ProvinciaId)
                    .HasConstraintName("FK_Canton_Provincia");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.Property(e => e.DireccionId)
                    .HasColumnName("DireccionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DescDireccion).HasMaxLength(50);

                entity.Property(e => e.DistritoId).HasColumnName("DistritoID");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Direccion)
                    .HasForeignKey(d => d.DistritoId)
                    .HasConstraintName("FK_Direccion_Distrito");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.Property(e => e.DistritoId)
                    .HasColumnName("DistritoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CantonId).HasColumnName("CantonID");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.Canton)
                    .WithMany(p => p.Distrito)
                    .HasForeignKey(d => d.CantonId)
                    .HasConstraintName("FK_Distrito_Canton");
            });

            modelBuilder.Entity<Identificador>(entity =>
            {
                entity.Property(e => e.IdentificadorId)
                    .HasColumnName("IdentificadorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TipoIdentificadorId).HasColumnName("TipoIdentificadorID");

                entity.HasOne(d => d.TipoIdentificador)
                    .WithMany(p => p.Identificador)
                    .HasForeignKey(d => d.TipoIdentificadorId)
                    .HasConstraintName("FK_Identificador_Tipo_Identificador");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.PersonaId)
                    .HasColumnName("PersonaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnotacionId).HasColumnName("AnotacionID");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DireccionId).HasColumnName("DireccionID");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.IdentificadorId).HasColumnName("IdentificadorID");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SegundoNombre).HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TipoPersonaId).HasColumnName("TipoPersonaID");

                entity.HasOne(d => d.Anotacion)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.AnotacionId)
                    .HasConstraintName("FK_Persona_Anotacion");

                entity.HasOne(d => d.Direccion)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.DireccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Direccion");

                entity.HasOne(d => d.Identificador)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.IdentificadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Identificador");

                entity.HasOne(d => d.TipoPersona)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.TipoPersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Tipo_Persona");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Relacion>(entity =>
            {
                entity.Property(e => e.RelacionId).HasColumnName("RelacionID");

                entity.Property(e => e.DescRelacion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoIdentificador>(entity =>
            {
                entity.HasKey(e => e.TipoIdentificadorId);

                entity.ToTable("Tipo_Identificador");

                entity.Property(e => e.TipoIdentificadorId).HasColumnName("Tipo_Identificador");

                entity.Property(e => e.DescTipoIdentificador)
                    .HasColumnName("DescTipo_Identificador")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoPersona>(entity =>
            {
                entity.ToTable("Tipo_Persona");

                entity.Property(e => e.TipoPersonaId).HasColumnName("TipoPersonaID");

                entity.Property(e => e.DescTipoPersona).HasMaxLength(50);
            });
        }
    }
}
