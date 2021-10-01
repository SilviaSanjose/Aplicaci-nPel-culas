using System.Collections.Generic;
using api.Entities;

namespace api.Services
{
    //interfaz
    public interface IMovieInfoRepository
    {   
        //IQueryable permite al consumidor del repositorio puede manipular la consulta con cláusulas de orden, where, etc...
        //IEnumerable para mantener limpio el controlador sin claúsulas 
        IEnumerable<Movie> GetMovies();   //método para todas las películas
        Movie GetMovie(int movieId);  //método para 1 película
        IEnumerable<Cast> GetCastsByMovie(int movieId);  //método para todo el cast de una película
        Cast GetCastByMovie(int movieId, int castId);  //método para un cast de una película
    }
}