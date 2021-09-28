namespace api.Services
{
    //interfaz creada desde localMailService para crear dependencias y que se pueda usar desde varias clases
    //en appsettings.json  incluimos datos de configuración
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}