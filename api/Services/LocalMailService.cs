using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace api.Services
{

    //vamos a crear un servicio como si enviara un email, pero se mostrará en la consola, cuando se elimina un cast
    public class LocalMailService : IMailService  //interfaz para crear dependencias
    {
        
        private IConfiguration _configuration;

        public LocalMailService(IConfiguration configuration)
        {
            _configuration= configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"El mail enviado de {_configuration["mailSettings:mailToAddress"]} a {_configuration["mailSettings:mailFromAddress"]} utilizando LocalMailService");
            Debug.WriteLine($"Asunto: {subject}");
            Debug.WriteLine($"Asunto: {message}");
        }

    }
}