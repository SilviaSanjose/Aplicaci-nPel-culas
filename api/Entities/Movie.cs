using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class Movie
    {
        [Key] //indica que es clave primaria. Entity Framework las key que son int o gui las añade automaticamente secuencialmente desde el valor 1
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //esto indica que genere el id automáticamente: al ser int no sería necesario poner esta anotación
        public int Id { get; set; }

        [Required ()]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required ()]
        [MaxLength(400)]
        public string Description{ get; set; }
        public ICollection<Cast> Casts { get; set;} = new List<Cast>();
    }
}