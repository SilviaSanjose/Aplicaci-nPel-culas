using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.ViewModel
{
    public class MovieViewModel
    {
        public Guid Id {get; set;}
        
        [Required(ErrorMessage = "El nombre es requerido")]  //decoradores de validación
        //[EmailAddress]
        public string Name {get; set; }

        [Required(ErrorMessage = "El género es requerido")]
        [MaxLength(20, ErrorMessage = "El género es muy largo, máximo 20 caracteres")]
        public string Genre {get; set; }
    }
}