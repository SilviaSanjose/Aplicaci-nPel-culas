using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
    //vamos a crear un servicio como si enviara un email, pero se mostrará en la consola, cuando se elimina un cast
    public class CloudMailService : IMailService //interfaz para crear dependencias
    {

        private IConfiguration _configuration;
        public CloudMailService(IConfiguration configuration){ //contructor que implementa la clase para usar configuraciones
            _configuration= configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        

        public void Send(string subject, string message){
            //direcciones se leen del archivo de configuración
            Debug.WriteLine($"El mail enviado de {_configuration["mailSettings:mailToAddress"]} a {_configuration["mailSettings:mailFromAddress"]} utilizando CloudMailService");
            Debug.WriteLine($"Asunto: {subject}");
            Debug.WriteLine($"Asunto: {message}");
        }
        
    }
}