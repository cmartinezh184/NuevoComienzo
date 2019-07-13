using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class Anotacion
    {
        public Anotacion()
        {
            Persona = new HashSet<Persona>();
        }

        public short AnotacionId { get; set; }
        public string DiagnosticoAprendizaje { get; set; }
        public string DiagnosticoPsicologico { get; set; }
        public string ObservacionesSupervisor { get; set; }
        public string Alergias { get; set; }
        public string Medicamentos { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
