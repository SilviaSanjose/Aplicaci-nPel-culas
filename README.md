# Nugget utilizados:

API:

- Petición Http Patch
  => Microsoft JsonPatch para gestionar peticiones patch
  => Newtonsoft.Json para añadir parámetro al ApplyTo; es temporal ya que se está revisando que el ModelState no genere error.

- Sacar log a archivos
  => NLog.Web.AspNetCore (https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-5)
  (Tutorial: https://github.com/NLog/NLog/wiki/Tutorial)
  crear archivo nlog.config
  Los logs se guardan en bin/debug/netcore/ file.txt

- Entity Framework
  => Microsoft.EntityFrameworkCore

  => Microsoft.EntityFrameworkCore.Sqlite

  => Microsoft.EntityFrameworkCore.Design Para trabajar con migraciones
  Consola: dotnet ef migrations add NombreDeLaMIgracionQueQuieras
  Para hacer migraciones desde consola: dotnet ef database update
  \*Es necesario tener instalado globalmente dotnet tool (dotnet tools install --global dotnet-ef)

  \*Migraciones automáticamente de genera el código en el main de program.cs y no hay que usar dotnet ef database update

  # appsetting.json

  Archivo donde se guardan las configuraciones
