using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
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
            return View();
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
        public IActionResult Enviar([Bind("nombre, correo, mensaje")]EmailModel emailmodel, string body)
        {
            var nombre = emailmodel.nombre;
            var correo = emailmodel.correo;
            var mensaje = emailmodel.mensaje;

        var message = new MimeMessage();

            /*Cambiar:
             * From.Add("nombre Fundacion", "correo Fundacion")
             * client.Authenticate("correo@gmail.com", "contraseña"); //(Cuenta de correo de la Fundación, Contraseña)
                
             */
            message.From.Add(new MailboxAddress(nombre, "infonuevocomienzocr@gmail.com")); //(Nombre del usuario, Cuenta de correo de la Fundación)
            message.To.Add(new MailboxAddress(nombre, "infonuevocomienzocr@gmail.com")); //A quien quieren que le llegue el correo. En este caso a la persona que lo envía. 
            message.Subject = "Mensaje para la Fundación Un Nuevo Comienzo";

            message.Body = new TextPart("html")
            {
                Text = "<b>"+nombre+"</b>"+ " ha consultado desde nuestra pagina web el siguiente mensaje: " 
                + "<br>" + "<b>" + "<br>" + mensaje + "<br>" + "</b>"+"<br>"+
                "<b>" + "¡Favor responder lo más pronto posible al correo " + correo + " !" + "</b>"
            };

            var message2 = new MimeMessage();
            message2.From.Add(new MailboxAddress("Correos Fundación Un Nuevo Comienzo", "fundacionunnuevocomienzocr@gmail.com")); //(Nombre del usuario, Cuenta de correo de la Fundación)
            message2.To.Add(new MailboxAddress(nombre, correo)); //A quien quieren que le llegue el correo. En este caso a la persona que lo envía. 
            message2.Subject = "Mensaje para la Fundación Un Nuevo Comienzo";

            message2.Body = new TextPart("html")
            {
                Text = "<b>" + "---------------------- Esta es una copia de su mensaje ----------------------" + "</b>" + "<br>" + nombre +
                " ha consultado desde el correo " + "<b>" + correo + "</b>" + " el siguiente mensaje:" 
                + "<br>" + "<b>" + "<br>" + mensaje + "<br>" + "</b>" + "<br>" +
                "Gracias por contactarnos. Responderemos por este medio lo más pronto posible."
                + "<br>" + "<br>" +
                "Puede contactarnos también por los siguientes medios: "
                + "<br>" + "<br>" +
                "Correo: " + "fundacionunnuevocomienzocr@gmail.com" + "<br>" +
                "Dirección: " + "350 metros al Norte del INA de Villa Esperanza de Pavas, Las Pavas." + "<br>" +
                "Horario de atención: " + "Lunes &mdash; Viernes 8:00am - 5:00pm" + "<br>" +
                "Facebook: " + "<a href = 'https://www.facebook.com/Fundaci%C3%B3n-Un-Nuevo-Comienzo-CR-1929896823952715/?epa=SEARCH_BOX' target ='_blank' ><span class='icon icon-facebook' ></span><span class='text' > Visita Nuestro Facebook, aquí</span></a>" + "<br>" +
                "Web: " + " <a href = 'fnuevocomienzocr.azurewebsites.net' target ='_blank'<span class='text' > Visita Nuestro Sitio Web, aquí</span></a>" + "<br>"
            };


            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("infonuevocomienzo@gmail.com", "Glopez.9963"); //(Cuenta de correo de la Fundación, Contraseña)
                client.Send(message);
                client.Disconnect(true);
            }

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("infonuevocomienzo@gmail.com", "Glopez.9963"); //(Cuenta de correo de la Fundación, Contraseña)
                client.Send(message2);
                client.Disconnect(true);
            }

            return View("ContactUs");
        }
    }
}
