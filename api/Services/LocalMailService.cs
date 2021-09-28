using System.Diagnostics;

namespace api.Services
{

    //vamos a crear un servicio como si enviara un email, pero se mostrará en la consola, cuando se elimina un cast
    public class LocalMailService : IMailService  //interfaz para crear dependencias
    {
        private string _emailTo = "admin@company.com";
        private string _emailFrom = "usar@useruser.com";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"El mail enviado de {_emailFrom} a {_emailTo} utilizando LocalMailService");
            Debug.WriteLine($"Asunto: {subject}");
            Debug.WriteLine($"Asunto: {message}");
        }

    }
}