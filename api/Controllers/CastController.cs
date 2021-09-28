using System.Linq;
using api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

//Controlador para el casting de casa película
namespace api.Controllers
{
    [ApiController] //eso des serializa
    [Route("api/movies/{movieId}/casts")]  //ruta que sólo se puede acceder desde el recurso movies indicando un número de id
    public class CastController: ControllerBase
    {
        private ILogger<CastController> _logger;
        //contrucctor para la inyección de dependencias
        public CastController(ILogger<CastController> logger){
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));   //si es nulo arroja excepción
        }

        [HttpGet]
        public IActionResult GetCasts(int movieId){   //Devuelve todo el casting de la película indicada, movieId lo recibe de la ruta
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x=> x.Id == movieId);
            if(movie == null){
                return NotFound();
            }
            return Ok(movie.Casts);
        }

        [HttpGet("{id}", Name="GetCast")]   //el nombre que usan las rutas de redirección
        public IActionResult GetCast(int movieId, int id){   //devuelve un único actor url/api/movies/a/casts/1   //GetActionResult
            try
            {
                throw new InvalidOperationException();
            
                var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x=> x.Id == movieId); //busca la película con el id
                if(movie == null){ //si no existe la película
                    return NotFound();
                }
                var cast = movie.Casts.FirstOrDefault(x=> x.Id == id);  //busca el cast
                if(cast == null){  //si no existe
                    _logger.LogInformation($"El cast con id {id} no fue encontrado");
                    return NotFound();
                }
                return Ok(cast);  //movie
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Un error ocurrió al buscar el cast con id {id}", ex);
                return StatusCode(500, "Ocurrió un error al realizar la petición");  //devolvemos un error personalizado al usuario
            }

        }

        [HttpPost]
        public IActionResult CreateCast(int movieId, [FromBody] CastForCreationDto castForCreationDto){  
            //[FromBody] indica que quiero des serializar lo que llega en el body. Si no se puede des serializar envía automáticamente un Bad Request

            //ejemlo para enviar un error personalizado si pasa X (en este caso nombre y personaje iguales)  //fluent validation libreria para errores
            //estos errores deberían estar en una clase a parte
            if(castForCreationDto.Name == castForCreationDto.Character){
                ModelState.AddModelError("Name", "El actor y el personaje no pueden ser iguales");
                return BadRequest(ModelState);
            }
            
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == movieId);
            if(movie == null){
                return NotFound();
            }
            //esto es para buscar el id mayor que haya guardado para así al crear nueva y darle el siguiente id (esto es tempoeral, ya se tratará como guardar id correlativos)
            var maxCastId = MoviesDataStore.Current.Movies.SelectMany(x => x.Casts).Max(p => p.Id);
            //mapear lo recogido en el body
            var newCast = new CastDto{
                Id = ++maxCastId,
                Name = castForCreationDto.Name,
                Character = castForCreationDto.Character
            };

            movie.Casts.Add(newCast);
            return CreatedAtRoute(   //devuelve una ruta
                nameof(GetCast),    //redirección al recurso indicado
                new {movieId, id= newCast.Id},
                castForCreationDto
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCast(int movieId, int id, [FromBody] CastForUpdateDto castForUpdateDto){
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == movieId);
            if(movie == null){
                return NotFound();
            }

            var castFromStore = movie.Casts.FirstOrDefault(x => x.Id == id);
            if(castFromStore == null){
                return NotFound();
            }

            castFromStore.Name = castForUpdateDto.Name;
            castFromStore.Character = castForUpdateDto.Character;

            return NoContent();  //no devolvemos nada, si no un 204 que indica recurso actualizado

        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateCast(int movieId, int id, [FromBody] JsonPatchDocument<CastForUpdateDto> patchDocument){
            //si patchDocument es null no hace falta indicarlo ya que lo hace automáticamente
            //se añade nuget Microsoft JsonPatch

            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == movieId);
            if(movie == null){
                return NotFound();
            }

            var castFromStore = movie.Casts.FirstOrDefault(x => x.Id == id);
            if(castFromStore == null){
                return NotFound();
            }

            var castToPatch = new CastForUpdateDto(){
                Name = castFromStore.Name,
                Character = castFromStore.Character
            };

            //ModelState dentro del ApplyTo da error por lo que se necesita instalar nuget Newtonsoft.Json .Es temporal ya que se está revisando para que no de el error
            patchDocument.ApplyTo(castToPatch, ModelState);  //aplicamos los cambios

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if(!TryValidateModel(castToPatch)){ //si no se cumplen las validaciones del modelo
                return BadRequest(ModelState);
            }
            castFromStore.Name = castToPatch.Name;   //actualizamos los datos aplicados
            castFromStore.Character = castToPatch.Character;

            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCast(int movieId, int id){
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == movieId);
            if(movie == null){
                return NotFound();
            }

            var castFromStore = movie.Casts.FirstOrDefault(x => x.Id == id);
            if(castFromStore == null){
                return NotFound();
            }

            movie.Casts.Remove(castFromStore);

            return NoContent();
        }
    }
}