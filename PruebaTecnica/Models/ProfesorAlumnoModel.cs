namespace PruebaTecnica.Models
{
    public class ProfesorAlumnoModel
    {
        public int Id { get; set; }
        public int IdProfesor { get; set; }
        public int IdEstudiante { get; set; }
        //Propiedades de navegacion
        public ProfesoresModel Profesor { get; set; }
        public EstudianteModel Estudiante { get; set; }
    }
}
