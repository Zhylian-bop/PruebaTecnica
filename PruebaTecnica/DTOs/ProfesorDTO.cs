using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.DTOs
{
    public class ProfesorDTO:RegistroDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo 'Nombre' es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo 'EscuelaId' es obligatorio.")]
        public int EscuelaId { get; set; }
    }
}
