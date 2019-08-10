using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSender.Video
{
    public class EnviarCorreo 
    {
        public bool Enviar(string to, string subject, string mensaje)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add(to);
            mmsg.Subject = subject;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Body = mensaje;
            mmsg.BodyEncoding= System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("gabohernand123@gmail.com");
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("gabohernand123@gmail.com", "Rosturama20");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";
            try
            {
                cliente.Send(mmsg);
                Console.WriteLine("Correo Enviado");
                Console.ReadLine();
            }
            catch (Exception e) {
                Console.WriteLine("Error al enviar email");
                Console.WriteLine(e);
                Console.ReadLine();
            }

            return true;
        }

        
    }
}
