using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoComienzo.Models
{
    using System.ComponentModel.DataAnnotations;

    namespace MVCEmail.Models
    {
        public class EmailFormModel
        {
            [Required, Display(Name = "Escribe tu Nombre")]
            public string FromName { get; set; }
            [Required, Display(Name = "Escribe tu Correo"), EmailAddress]
            public string FromEmail { get; set; }
            [Required]
            public string Message { get; set; }
        }
    }
}
