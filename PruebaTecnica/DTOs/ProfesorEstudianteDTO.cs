using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.DTOs
{
    public class ProfesorEstudianteDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo 'IdProfesor' es obligatorio.")]
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "El campo 'IdEstudiante' es obligatorio.")]
        public int IdEstudiante { get; set; }
    }
}
