using System.Collections.Generic;
using api.Models;

namespace api
{
    public class MoviesDataStore
    {
        public static MoviesDataStore Current {get; } = new MoviesDataStore();  //variable estática para obtener las películas actuales
        public List<MovieDto> Movies {get; set;} //variable/lista donde se van a ir guardando las películas
        public MoviesDataStore(){
            Movies = new List<MovieDto>(){
                new MovieDto(){
                    Id = 1,
                    Name = "Gans of New York",
                    Description = "Película histórica sobre gansters", 
                    Casts = new List<CastDto>(){
                        new CastDto {Id=1, Name = "Daniel Day-lewis", Character= "the man"},
                        new CastDto {Id=2, Name = "Leonardo Di Caprio", Character= "the man2"},
                    }
                },
                new MovieDto(){
                    Id = 2,
                    Name = "El mago de OZ",
                    Description = "Película de fantasía donde una chica tras sufir un golpe entra en un sueño que es como un nuevo mundo muy real",
                    Casts = new List<CastDto>(){
                        new CastDto {Id=1, Name = "Susan HAydf", Character= "Dorothy"},
                        new CastDto {Id=2, Name = "Leonardo HHHH", Character= "The Lion"},
                    }
                },
                new MovieDto(){
                    Id = 3,
                    Name = "Forest Gump",
                    Description = "Relata la vida de un chico con un cierto retraso y sus ganas de vivir y demostrar su valía",
                    Casts = new List<CastDto>(){
                        new CastDto {Id=1, Name = "¨Tom Hanks", Character= "Forest"},
                        new CastDto {Id=2, Name = "Yulianna jghdf", Character= "the woman"},
                    }
                }
            };
        }
    }
}