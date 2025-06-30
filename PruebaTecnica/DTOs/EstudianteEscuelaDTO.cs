using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.DTOs
{
    public class EstudianteEscuelaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo 'IdEstudiante' es obligatorio.")]
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "El campo 'IdEscuela' es obligatorio.")]
        public int IdEscuela { get; set; }
    }
}
