using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class TipoIdentificador
    {
        public TipoIdentificador()
        {
            Identificador = new HashSet<Identificador>();
        }

        public sbyte TipoIdentificadorId { get; set; }
        public string DescTipoIdentificador { get; set; }

        public virtual ICollection<Identificador> Identificador { get; set; }
    }
}
