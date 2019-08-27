using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NuevoComienzo.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anotacion> Anotacion { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Identificador> Identificador { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<TipoIdentificador> TipoIdentificador { get; set; }
        public virtual DbSet<TipoPersona> TipoPersona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=198.71.227.91;port=3306;database=fnuevocomienzodb;uid=fncdbadmin;password=%a723zAu");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Anotacion>(entity =>
            {
                entity.Property(e => e.AnotacionId).HasColumnName("AnotacionID");
            });

            // Map Table
            modelBuilder.Entity<IdentityUser>().ToTable("aspnet_user");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("aspnet_user_login");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("aspnet_user_claim");
            modelBuilder.Entity<IdentityRole>().ToTable("aspnet_role");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("aspnet_user_role");

            // Map Columns
            modelBuilder.Entity<IdentityUser>().Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityUser>().Property(u => u.Email).HasColumnName("email");
            modelBuilder.Entity<IdentityUser>().Property(u => u.EmailConfirmed).HasColumnName("email_confirmed");
            modelBuilder.Entity<IdentityUser>().Property(u => u.PasswordHash).HasColumnName("password_hash");
            modelBuilder.Entity<IdentityUser>().Property(u => u.SecurityStamp).HasColumnName("security_stamp");
            modelBuilder.Entity<IdentityUser>().Property(u => u.PhoneNumber).HasColumnName("phone_number");
            modelBuilder.Entity<IdentityUser>().Property(u => u.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
            modelBuilder.Entity<IdentityUser>().Property(u => u.TwoFactorEnabled).HasColumnName("two_factor_enabled");
            modelBuilder.Entity<IdentityUser>().Property(u => u.LockoutEnabled).HasColumnName("lockout_enabled");
            modelBuilder.Entity<IdentityUser>().Property(u => u.AccessFailedCount).HasColumnName("access_failed_count");
            modelBuilder.Entity<IdentityUser>().Property(u => u.UserName).HasColumnName("user_name");

            modelBuilder.Entity<IdentityRole>().Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityRole>().Property(u => u.Name).HasColumnName("name");

            modelBuilder.Entity<IdentityUserRole<string>>().Property(u => u.UserId).HasColumnName("user_id");
            modelBuilder.Entity<IdentityUserRole<string>>().Property(u => u.RoleId).HasColumnName("role_id");

            modelBuilder.Entity<IdentityUserClaim<string>>().Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityUserClaim<string>>().Property(u => u.UserId).HasColumnName("user_id");
            modelBuilder.Entity<IdentityUserClaim<string>>().Property(u => u.ClaimType).HasColumnName("claim_type");
            modelBuilder.Entity<IdentityUserClaim<string>>().Property(u => u.ClaimValue).HasColumnName("claim_value");

            modelBuilder.Entity<IdentityUserLogin<string>>().Property(u => u.LoginProvider).HasColumnName("login_provider");
            modelBuilder.Entity<IdentityUserLogin<string>>().Property(u => u.LoginProvider).HasColumnName("provider_key");
            modelBuilder.Entity<IdentityUserLogin<string>>().Property(u => u.LoginProvider).HasColumnName("user_id");

         
            modelBuilder.Entity<Canton>(entity =>
            {
                entity.Property(e => e.CantonId).HasColumnName("CantonID");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Canton)
                    .HasForeignKey(d => d.ProvinciaId)
                    .HasConstraintName("FK_Canton_Provincia");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.Property(e => e.DireccionId).HasColumnName("DireccionID");

                entity.Property(e => e.DescDireccion).HasMaxLength(50);

                entity.Property(e => e.DistritoId).HasColumnName("DistritoID");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Direccion)
                    .HasForeignKey(d => d.DistritoId)
                    .HasConstraintName("FK_Direccion_Distrito");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.Property(e => e.DistritoId).HasColumnName("DistritoID");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Identificador_Tipo_Identificador");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.PersonaId).HasColumnName("PersonaID");

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
                entity.Property(e => e.ProvinciaId)
                    .HasColumnName("ProvinciaID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoIdentificador>(entity =>
            {
                entity.Property(e => e.TipoIdentificadorId).HasColumnName("TipoIdentificadorID");

                entity.Property(e => e.DescTipoIdentificador).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoPersona>(entity =>
            {
                entity.Property(e => e.TipoPersonaId).HasColumnName("TipoPersonaID");

                entity.Property(e => e.DescTipoPersona).HasMaxLength(50);
            });
        }
    }
}
