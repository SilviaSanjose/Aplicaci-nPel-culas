using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    //clase para la creación de datos
    public class CastForCreationDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "El nombre es requerido")]  //mensaje que saldrá en la repuesta del post si no se cumplen los requisitos
        public string Name { get; set;}
        [Required (ErrorMessage ="El personaje es requerido")]
        public string Character{ get; set;}
    }
}