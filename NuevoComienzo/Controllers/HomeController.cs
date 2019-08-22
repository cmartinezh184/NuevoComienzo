using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuevoComienzo.Models.MVCEmail;
using NuevoComienzo.Models.MVCEmail.Models;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MailKit.Net.Smtp;
using NuevoComienzo.Models;

namespace NuevoComienzo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Gabriel Hernandez", "gabohernand123@gmail.com"));
            message.To.Add(new MailboxAddress("Robert Ramirez", "rsft6000@gmail.com"));
            message.Subject = "Hola Robert";
            message.Body = new TextPart("plain")
            {
                Text = "Gracias por escrbirnos. La respuesta llegará en breve a su correo"
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("gabohernand123@gmail.com", "Rosturama20");
                client.Send(message);
                client.Disconnect(true);
            }
            return View();
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

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(string nombre, string correo, string mensaje)
        {
            EmailFormModel email = new EmailFormModel();
            email.FromName = nombre;
            email.FromEmail = correo;
            email.Message = mensaje;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Gabriel Hernandez", "gabohernand123@gmail.com"));
            message.To.Add(new MailboxAddress("Robert Ramirez", "rsft6000@gmail.com"));
            message.Subject = "Hola Robert";
            message.Body = new TextPart("plain")
            {
                Text = "Gracias por escrbirnos {FromName}. La respuesta llegará en breve a su correo"
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("gabohernand123@gmail.com", "Rosturama20");
                client.Send(message);
                client.Disconnect(true);
            }
            return View(email);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}
