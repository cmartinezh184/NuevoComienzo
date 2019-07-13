using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class TipoPersona
    {
        public TipoPersona()
        {
            Persona = new HashSet<Persona>();
        }

        public byte TipoPersonaId { get; set; }
        public string DescTipoPersona { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
