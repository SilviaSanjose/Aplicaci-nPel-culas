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
            //Database.EnsureCreated(); //se asegura que la bbdd está creada y si no está, la crea. Al trabajar con migraciones no es necesario esto ya que la bbdd se crea con la primera migracion

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //añadir datos a bbdd
            modelBuilder.Entity<Movie>().HasData(
                new Movie {
                    Id = 1,
                    Name = "Silvia",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                },
                new Movie {
                    Id = 2,
                    Name = "Antonio",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                });

            modelBuilder.Entity<Cast>().HasData(
                new Cast {
                    Id = 1,
                    Name = "Silvia",
                    Character = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    MovieId = 1
                },
                new Cast {
                    Id = 2,
                    Name = "Antonio",
                    Character = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    MovieId = 1
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}