using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Direccion = new HashSet<Direccion>();
        }

        public int DistritoId { get; set; }
        public string Nombre { get; set; }
        public short? CantonId { get; set; }

        public virtual Canton Canton { get; set; }
        public virtual ICollection<Direccion> Direccion { get; set; }
    }
}
