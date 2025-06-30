using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.DTOs
{
    public class EscuelaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
