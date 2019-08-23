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
        public IActionResult Index()
        {
            /*
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Fundacion", "gabohernand123@gmail.com"));
            message.To.Add(new MailboxAddress("Robert Ramirez", "rsft6000@gmail.com"));
            message.Subject = "Fundación Un Nuevo Comienzo";
            message.Body = new TextPart("plain")
            {
                Text = message + "Gracias por escribirnos {FromName}. La respuesta llegará en breve a su correo"
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, true);
                client.Authenticate("gabohernand123@gmail.com", "Rosturama20");
                client.Send(message);
                client.Disconnect(true);
            }*/

            return View(email);
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Programs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
