﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NuevoComienzo.Models;

namespace NuevoComienzo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("aspnet_role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasColumnName("user_name")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("aspnet_user");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("aspnet_user_claim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("user_id")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("aspnet_user_login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("aspnet_user_role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Anotacion", b =>
                {
                    b.Property<short>("AnotacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AnotacionID");

                    b.Property<string>("Alergias");

                    b.Property<string>("DiagnosticoAprendizaje");

                    b.Property<string>("DiagnosticoPsicologico");

                    b.Property<string>("Medicamentos");

                    b.Property<string>("ObservacionesSupervisor");

                    b.HasKey("AnotacionId");

                    b.ToTable("Anotacion");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Canton", b =>
                {
                    b.Property<short>("CantonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CantonID");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.Property<sbyte?>("ProvinciaId")
                        .HasColumnName("ProvinciaID");

                    b.HasKey("CantonId");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Canton");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Direccion", b =>
                {
                    b.Property<int>("DireccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DireccionID");

                    b.Property<string>("DescDireccion")
                        .HasMaxLength(50);

                    b.Property<int?>("DistritoId")
                        .HasColumnName("DistritoID");

                    b.HasKey("DireccionId");

                    b.HasIndex("DistritoId");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Distrito", b =>
                {
                    b.Property<int>("DistritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DistritoID");

                    b.Property<short?>("CantonId")
                        .HasColumnName("CantonID");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.HasKey("DistritoId");

                    b.HasIndex("CantonId");

                    b.ToTable("Distrito");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Identificador", b =>
                {
                    b.Property<int>("IdentificadorId")
                        .HasColumnName("IdentificadorID");

                    b.Property<sbyte>("TipoIdentificadorId")
                        .HasColumnName("TipoIdentificadorID");

                    b.HasKey("IdentificadorId");

                    b.HasIndex("TipoIdentificadorId");

                    b.ToTable("Identificador");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PersonaID");

                    b.Property<short?>("AnotacionId")
                        .HasColumnName("AnotacionID");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("DireccionId")
                        .HasColumnName("DireccionID");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<int>("IdentificadorId")
                        .HasColumnName("IdentificadorID");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SegundoNombre")
                        .HasMaxLength(50);

                    b.Property<string>("Sexo");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<sbyte>("TipoPersonaId")
                        .HasColumnName("TipoPersonaID");

                    b.HasKey("PersonaId");

                    b.HasIndex("AnotacionId");

                    b.HasIndex("DireccionId");

                    b.HasIndex("IdentificadorId");

                    b.HasIndex("TipoPersonaId");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Provincia", b =>
                {
                    b.Property<sbyte>("ProvinciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProvinciaID");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.HasKey("ProvinciaId");

                    b.ToTable("Provincia");
                });

            modelBuilder.Entity("NuevoComienzo.Models.TipoIdentificador", b =>
                {
                    b.Property<sbyte>("TipoIdentificadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TipoIdentificadorID");

                    b.Property<string>("DescTipoIdentificador")
                        .HasMaxLength(50);

                    b.HasKey("TipoIdentificadorId");

                    b.ToTable("TipoIdentificador");
                });

            modelBuilder.Entity("NuevoComienzo.Models.TipoPersona", b =>
                {
                    b.Property<sbyte>("TipoPersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TipoPersonaID");

                    b.Property<string>("DescTipoPersona")
                        .HasMaxLength(50);

                    b.HasKey("TipoPersonaId");

                    b.ToTable("TipoPersona");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NuevoComienzo.Models.Canton", b =>
                {
                    b.HasOne("NuevoComienzo.Models.Provincia", "Provincia")
                        .WithMany("Canton")
                        .HasForeignKey("ProvinciaId")
                        .HasConstraintName("FK_Canton_Provincia");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Direccion", b =>
                {
                    b.HasOne("NuevoComienzo.Models.Distrito", "Distrito")
                        .WithMany("Direccion")
                        .HasForeignKey("DistritoId")
                        .HasConstraintName("FK_Direccion_Distrito");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Distrito", b =>
                {
                    b.HasOne("NuevoComienzo.Models.Canton", "Canton")
                        .WithMany("Distrito")
                        .HasForeignKey("CantonId")
                        .HasConstraintName("FK_Distrito_Canton");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Identificador", b =>
                {
                    b.HasOne("NuevoComienzo.Models.TipoIdentificador", "TipoIdentificador")
                        .WithMany("Identificador")
                        .HasForeignKey("TipoIdentificadorId")
                        .HasConstraintName("FK_Identificador_Tipo_Identificador");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Persona", b =>
                {
                    b.HasOne("NuevoComienzo.Models.Anotacion", "Anotacion")
                        .WithMany("Persona")
                        .HasForeignKey("AnotacionId")
                        .HasConstraintName("FK_Persona_Anotacion");

                    b.HasOne("NuevoComienzo.Models.Direccion", "Direccion")
                        .WithMany("Persona")
                        .HasForeignKey("DireccionId")
                        .HasConstraintName("FK_Persona_Direccion");

                    b.HasOne("NuevoComienzo.Models.Identificador", "Identificador")
                        .WithMany("Persona")
                        .HasForeignKey("IdentificadorId")
                        .HasConstraintName("FK_Persona_Identificador");

                    b.HasOne("NuevoComienzo.Models.TipoPersona", "TipoPersona")
                        .WithMany("Persona")
                        .HasForeignKey("TipoPersonaId")
                        .HasConstraintName("FK_Persona_Tipo_Persona");
                });
#pragma warning restore 612, 618
        }
    }
}