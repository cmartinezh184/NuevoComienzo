using EmailSender.Video;
using System;

namespace EmailSender
{
    class Program
    {
        static void Main(string[] args)
        {

            EnviarCorreo env = new EnviarCorreo();

            env.Enviar("rsft6000@gmail.com", "Correo de Prueba", "Hola");
            
        }
    }
}
