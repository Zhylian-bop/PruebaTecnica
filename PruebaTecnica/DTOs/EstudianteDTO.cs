using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.DTOs
{
    public class EstudianteDTO :RegistroDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }
}
