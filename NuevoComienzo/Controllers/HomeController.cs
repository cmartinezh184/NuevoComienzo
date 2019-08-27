using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NuevoComienzo.Models;

namespace NuevoComienzo.Controllers
{
    public class HomeController : Controller
    {

        public string PostedMessage { get; set; } = "";

        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string message { get; set; }
        /// <summary>
        /// Metodo que llama a la pagina principal
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(email);
        }

        /// <summary>
        /// Llama a la pagina de Sobre Nosotros
        /// </summary>
        /// <returns></returns>
        public IActionResult AboutUs()
        {
            return View();
        }

        /// <summary>
        /// Llama a la pagina de Patrocinadores
        /// </summary>
        /// <returns></returns>
        public IActionResult Programs()
        {
            return View();
        }

        /// <summary>
        /// Llama a la pagina de Contactenos
        /// </summary>
        /// <returns></returns>
        public IActionResult ContactUs()
        {
            return View();
        }

        /// <summary>
        /// Llama a la pagina de Galeria
        /// </summary>
        /// <returns></returns>
        public IActionResult Gallery()
        {
            return View();
        }
        /// <summary>
        /// Metodo que devuelve el error que se dio con la pagina actual
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
