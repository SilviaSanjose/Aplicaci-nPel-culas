using System.Collections.Generic;
using api.Entities;

namespace api.Services
{
    public class MoviInfoRepository : IMovieInfoRepository
    {
        public Cast GetCastByMovie(int movieId, int castId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Cast> GetCastsByMovie(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public Movie GetMovie(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Movie> GetMovies()
        {
            throw new System.NotImplementedException();
        }
    }
}