using System.ComponentModel.DataAnnotations;

namespace Ejemplo01.Models
{
    public class Amigo
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Oblogatorio"), MaxLength(100, ErrorMessage="No mas de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage="Oblogatorio")]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage="Seleccione una opcion")]
        public Provincia? Ciudad { get; set; }

        public string Rutafoto { get; set; }
    }
}