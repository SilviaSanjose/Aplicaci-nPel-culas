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
