﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NuevoComienzo.Data;

namespace NuevoComienzo.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190713132041_FourthMigration")]
    partial class FourthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<byte?>("ProvinciaId");

                    b.HasKey("CantonId");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Canton");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Direccion", b =>
                {
                    b.Property<int>("DireccionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescDireccion");

                    b.Property<int?>("DistritoId");

                    b.HasKey("DireccionId");

                    b.HasIndex("DistritoId");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Distrito", b =>
                {
                    b.Property<int>("DistritoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("CantonId");

                    b.Property<string>("Nombre");

                    b.HasKey("DistritoId");

                    b.HasIndex("CantonId");

                    b.ToTable("Distrito");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Identificador", b =>
                {
                    b.Property<int>("IdentificadorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescIdentificador");

                    b.Property<byte?>("TipoIdentificadorId");

                    b.HasKey("IdentificadorId");

                    b.HasIndex("TipoIdentificadorId");

                    b.ToTable("Identificador");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Persona", b =>
                {
                    b.Property<Guid>("PersonaId")
                        .ValueGeneratedOnAdd();

                    b.Property<short?>("AnotacionId");

                    b.Property<string>("Correo");

                    b.Property<int>("DireccionId");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<int>("IdentificadorId");

                    b.Property<string>("PrimerApellido");

                    b.Property<string>("PrimerNombre");

                    b.Property<string>("SegundoApellido");

                    b.Property<string>("SegundoNombre");

                    b.Property<bool>("Sexo");

                    b.Property<string>("Telefono");

                    b.Property<byte>("TipoPersonaId");

                    b.HasKey("PersonaId");

                    b.HasIndex("AnotacionId");

                    b.HasIndex("DireccionId");

                    b.HasIndex("IdentificadorId");

                    b.HasIndex("TipoPersonaId");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Provincia", b =>
                {
                    b.Property<byte>("ProvinciaId");

                    b.Property<string>("Nombre");

                    b.HasKey("ProvinciaId");

                    b.ToTable("Provincia");
                });

            modelBuilder.Entity("NuevoComienzo.Models.TipoIdentificador", b =>
                {
                    b.Property<byte>("TipoIdentificadorID");

                    b.Property<string>("DescTipoIdentificador");

                    b.HasKey("TipoIdentificadorID");

                    b.ToTable("TipoIdentificador");
                });

            modelBuilder.Entity("NuevoComienzo.Models.TipoPersona", b =>
                {
                    b.Property<byte>("TipoPersonaId");

                    b.Property<string>("DescTipoPersona");

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
                        .HasForeignKey("ProvinciaId");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Direccion", b =>
                {
                    b.HasOne("NuevoComienzo.Models.Distrito", "Distrito")
                        .WithMany("Direccion")
                        .HasForeignKey("DistritoId");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Distrito", b =>
                {
                    b.HasOne("NuevoComienzo.Models.Canton", "Canton")
                        .WithMany("Distrito")
                        .HasForeignKey("CantonId");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Identificador", b =>
                {
                    b.HasOne("NuevoComienzo.Models.TipoIdentificador", "TipoIdentificador")
                        .WithMany("Identificador")
                        .HasForeignKey("TipoIdentificadorId");
                });

            modelBuilder.Entity("NuevoComienzo.Models.Persona", b =>
                {
                    b.HasOne("NuevoComienzo.Models.Anotacion", "Anotacion")
                        .WithMany("Persona")
                        .HasForeignKey("AnotacionId");

                    b.HasOne("NuevoComienzo.Models.Direccion", "Direccion")
                        .WithMany("Persona")
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NuevoComienzo.Models.Identificador", "Identificador")
                        .WithMany("Persona")
                        .HasForeignKey("IdentificadorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NuevoComienzo.Models.TipoPersona", "TipoPersona")
                        .WithMany("Persona")
                        .HasForeignKey("TipoPersonaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
