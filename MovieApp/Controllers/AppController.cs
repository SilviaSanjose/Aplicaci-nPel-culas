using Microsoft.AspNetCore.Mvc;
using System;
using MovieApp.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Controllers

{
    public class AppController : Controller   //debe heredar siempre la clase controller
    {
        //creo variable movies, de tipo lista de mi clase
        private static List<MovieViewModel> _movies = new List<MovieViewModel>();
        public IActionResult Index()
        {
            return View(_movies);
        }

        public IActionResult AddOrEdit(Guid id)   //está es la acción de la vista
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            return View();
        }

        [HttpPost]   //decorador que indica que será un post la llamada del formulario
        public IActionResult AddOrEdit(MovieViewModel model)   //acción al guardar
        {
            var movie = _movies.FirstOrDefault(x => x.Id == model.Id);
            if(ModelState.IsValid){  //comprueba si son válidos según lo definido en el modelo
                if(movie == null){
                    model.Id = Guid.NewGuid();
                    _movies.Add(model);
                    Console.WriteLine(model.Name, model.Id);
                }else{
                    movie.Genre = model.Genre;
                    movie.Name = model.Name;
                    Console.WriteLine(model.Name, model.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("No válido", model.Name);
            return View();
        }

        public IActionResult Delete(Guid id){
            _movies.Remove(_movies.FirstOrDefault(x => x.Id == id));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("about")]  //otra forma de enrutamiento, la url es directamente /about con decorador
        public IActionResult About()   
        {
            //throw new InvalidOperationException();
            return View();
        }


    }
}