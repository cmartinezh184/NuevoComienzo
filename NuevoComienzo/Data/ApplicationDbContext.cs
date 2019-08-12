using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuevoComienzo.Models;

namespace NuevoComienzo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NuevoComienzo.Models.Persona> Persona { get; set; }
        public virtual DbSet<Anotacion> Anotacion { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Identificador> Identificador { get; set; }
        public virtual DbSet<Relacion> Relacion { get; set; }
        public virtual DbSet<TipoIdentificador> TipoIdentificador { get; set; }
    }
}
