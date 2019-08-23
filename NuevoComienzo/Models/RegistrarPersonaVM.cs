using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoComienzo.Models
{
    public class RegistrarPersonaVM
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public sbyte TipoPersonaId { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public sbyte TipoIdentificadorId { get; set; }
        public int IdentificadorId { get; set; }
        public string DescDireccion { get; set; }
        public int? DistritoId { get; set; }
        public short? CantonId { get; set; }
        public sbyte ProvinciaId { get; set; }
        public string DiagnosticoAprendizaje { get; set; }
        public string DiagnosticoPsicologico { get; set; }
        public string ObservacionesSupervisor { get; set; }
        public string Alergias { get; set; }
        public string Medicamentos { get; set; }

    }
}
