using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class Canton
    {
        public Canton()
        {
            Distrito = new HashSet<Distrito>();
        }

        public short CantonId { get; set; }
        public string Nombre { get; set; }
        public byte? ProvinciaId { get; set; }

        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Distrito> Distrito { get; set; }
    }
}
