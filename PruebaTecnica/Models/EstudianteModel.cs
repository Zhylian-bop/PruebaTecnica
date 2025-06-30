namespace PruebaTecnica.Models
{
    public class EstudianteModel:RegistroModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        // Relaciones
        public IEnumerable<ProfesorEstudianteModel> ProfesorAlumnos { get; set; }
        public IEnumerable<EstudianteEscuelaModel> AlumnoEscuelas { get; set; }
    }
}
