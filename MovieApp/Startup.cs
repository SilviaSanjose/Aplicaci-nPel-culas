using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MovieApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();    //necesario para cargar los views
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())   //si es de desarrollo (se ve en properties/launchSettings)
            {
                app.UseDeveloperExceptionPage();   //muestra errores en pantalla
            }else {
                app.UseExceptionHandler("/error");
            }

            //middleware para indicar que queremos mostrar archivos estáticos
            //app.UseDefaultFiles();   //indica que use el archivo por defecto (Index) al carga la página. No lo usamos al utilizar MVC
            
            app.UseStaticFiles();   //indica que debe servir estáticos

            app.UseRouting();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });*/
            
            app.UseEndpoints(x =>{
               // x.MapRazorPages();  //redireccionar para razor pages que no  tienen controller.
                x.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", Action = "Index"}
                );
            });

            
        }
    }
}
