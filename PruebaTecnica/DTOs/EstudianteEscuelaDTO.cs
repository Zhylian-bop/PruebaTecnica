using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.DTOs
{
    public class EstudianteEscuelaDTO:RegistroDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo 'IdEstudiante' es obligatorio.")]
        public int EstudianteId { get; set; }
        [Required(ErrorMessage = "El campo 'IdEscuela' es obligatorio.")]
        public int EscuelaId { get; set; }
    }
}
