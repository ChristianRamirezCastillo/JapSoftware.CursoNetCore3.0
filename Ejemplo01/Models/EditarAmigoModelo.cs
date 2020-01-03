using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Ejemplo01.Models
{
    public class EditarAmigoModelo: CrearAmigoModelo
    {
        public int Id { get; set; }
        
        public string RutaFotoExistente { get; set; }
    }
}