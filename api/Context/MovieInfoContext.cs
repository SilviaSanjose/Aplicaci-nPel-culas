using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class MovieInfoContext : DbContext
    {
        //DbSet indica que cada update, delete, etc... se va a mapear en la entidad indicada
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Cast> Casts { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("connectionString");
            base.OnConfiguring(optionsBuilder);
        }*/
        public MovieInfoContext(DbContextOptions<MovieInfoContext> options) : base(options){
            //lo que recibe el contrucctor lo lleva directamente al construcdor base de la clase DbContext
            Database.EnsureCreated(); //se asegura que la bbdd está creada y si no está, la crea.

        }
    }
}