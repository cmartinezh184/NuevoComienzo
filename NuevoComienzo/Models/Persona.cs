using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class Persona
    {
        public int PersonaId { get; set; }
        public sbyte TipoPersonaId { get; set; }
        public int IdentificadorId { get; set; }
        public int DireccionId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public short? AnotacionId { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public virtual Anotacion Anotacion { get; set; }

        public virtual Direccion Direccion { get; set; }
        public virtual Identificador Identificador { get; set; }
        public virtual TipoPersona TipoPersona { get; set; }
    }
}
