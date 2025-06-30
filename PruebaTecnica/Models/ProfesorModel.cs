namespace PruebaTecnica.Models
{
    public class ProfesorModel:RegistroModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int EscuelaId { get; set; }
        // Relaciones
        public IEnumerable<ProfesorEstudianteModel> ProfesorAlumnos { get; set; }
        public EscuelaModel Escuela { get; set; }
    }
}
