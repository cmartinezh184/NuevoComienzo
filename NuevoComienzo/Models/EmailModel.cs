using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoComienzo.Models
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    public class EmailModel
    {
        public string nombre { get; set; }
        public string correo { get; set; }
        public string mensaje { get; set; }
    }
}
