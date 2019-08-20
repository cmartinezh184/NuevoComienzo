using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class Identificador
    {
        public Identificador()
        {
            Persona = new HashSet<Persona>();
        }

        public int IdentificadorId { get; set; }
        public byte TipoIdentificadorId { get; set; }

        public virtual TipoIdentificador TipoIdentificador { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
