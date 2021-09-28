using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


//Controlador para las películas
namespace api.Controllers
{
    [ApiController]  //recomendable para devolver errores
    [Route("api/movies")]  //ponemos la ruta general que van a llevar todos mos métodos
    public class MoviesController: ControllerBase   //mejor que Controller para cuando sean api que no usan vistas
    {
       // [HttpGet("api/movies")]  no es necesario al estar en la ruta
        public IActionResult GetMovies(){
            return Ok(MoviesDataStore.Current.Movies);
        }

//obtener una película
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id){
            
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == id); //busca el id pasado en ruta con alguno guardado
            if(movie == null){
                return NotFound();
            }
            return Ok(movie);
        }
    }
}