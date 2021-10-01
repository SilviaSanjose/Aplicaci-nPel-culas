using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class Cast
    {
        [Key]  //indica que es clave primaria. Entity Framework las key que son int o gui las añade automaticamente secuencialmente desde el valor 1
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required (ErrorMessage = "El nombre es requerido")]
        [MaxLength(50)]
        public string Name { get; set;}

        [Required (ErrorMessage ="El personaje es requerido")]
        [MaxLength(50)]
        public string Character{ get; set;}

        [ForeignKey("MovieId")]  //anotación unida a la propedad MovieId, sólo recomensable
        public Movie Movie {get; set;} //con esta propiedad EF sabe que es clave foragian de la PK de Movie
        public int MovieId { get; set; }  //esto indica cual es la PK. Es algo no necesario con la propiedad de arriba, pero si recomendable

        public int? Age { get; set;}   //? indica que permite nulos
    }
}