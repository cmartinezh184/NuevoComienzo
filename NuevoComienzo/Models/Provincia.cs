using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Canton = new HashSet<Canton>();
        }

        public byte ProvinciaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Canton> Canton { get; set; }
    }
}
