namespace PruebaTecnica.Models
{
    public class EscuelaModel : RegistroModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        // Relaciones
        public List<ProfesorAlumnoModel> ProfesorAlumnos { get; set; } = new List<ProfesorAlumnoModel>();
        public List<AlumnoEscuelaModel> AlumnoEscuelas { get; set; } = new List<AlumnoEscuelaModel>();
        public List<ProfesoresModel> Profesores { get; set; } = new List<ProfesoresModel>();
    }
}
