using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class Direccion
    {
        public Direccion()
        {
            Persona = new HashSet<Persona>();
        }

        public int DireccionId { get; set; }
        public string DescDireccion { get; set; }
        public int? DistritoId { get; set; }

        public virtual Distrito Distrito { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
