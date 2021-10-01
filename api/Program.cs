using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();  //crea host, lo construye y o arranca. Lo sustituimos por otro código para usar migraciones con EF:
            var host = CreateHostBuilder(args).Build(); //creamos y contruimos el host

            using (var scope = host.Services.CreateScope()){   //coger los servicios y crear scope par apoder accceder a l instancia de MovieInfoContext ya que desde
                        //program.cs no hay acceso al contenedor de dependencias, pero se puede pedir una instancia de una clase con CreateScope.
                var services = scope.ServiceProvider;
                try {
                    var context = services.GetRequiredService<MovieInfoContext>();  //pido la instancia y la almaceno
                
                    context.Database.EnsureDeleted();  //comentar para producción ya que es para comenzar con la bbdd limpia
                    context.Database.Migrate();
                }
                catch (Exception ex){
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Un error ocurrió durante la migración");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseNLog();  //nuget Nlog que se integra con ILogger
                });
    }
}

/*CreateHostBuilder ya incluye un logger, lo que nos permite inyectar dependencias sin implementar nada más. 
Lo habitual es hacerlo en el contructor de cada clase (ejem: CastController*/