namespace PruebaTecnica.Models
{
    public class EstudiantesModel:RegistroModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        // Relaciones
        public List<ProfesorAlumnoModel> ProfesorAlumnos { get; set; } = new List<ProfesorAlumnoModel>();
        public List<AlumnoEscuelaModel> AlumnoEscuelas { get; set; } = new List<AlumnoEscuelaModel>();
    }
}
