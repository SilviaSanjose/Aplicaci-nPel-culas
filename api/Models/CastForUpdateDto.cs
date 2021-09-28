using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class CastForUpdateDto
    {
        [Required (ErrorMessage = "El nombre es requerido")]  //mensaje que saldrá en la repuesta del post si no se cumplen los requisitos
        public string Name { get; set;}
       // [Required (ErrorMessage ="El personaje es requerido")]
        public string Character{ get; set;} 
    }
}