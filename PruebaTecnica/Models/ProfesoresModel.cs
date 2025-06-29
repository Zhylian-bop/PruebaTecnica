namespace PruebaTecnica.Models
{
    public class ProfesoresModel:RegistroModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int IdEscuela { get; set; }
        // Relaciones
        public List<ProfesorAlumnoModel> ProfesorAlumnos { get; set; } = new List<ProfesorAlumnoModel>();
    }
}
