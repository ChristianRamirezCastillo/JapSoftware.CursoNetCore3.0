using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Ejemplo01.Models
{
    public class CrearAmigoModelo
    {

        [Required(ErrorMessage="Oblogatorio"), MaxLength(100, ErrorMessage="No mas de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage="Oblogatorio")]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage="Seleccione una opcion")]
        public Provincia? Ciudad { get; set; }

        public IFormFile Foto { get; set; }
    }
}