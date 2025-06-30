namespace PruebaTecnica.Models
{
    public class ProfesorEstudianteModel
    {
        public int Id { get; set; }
        public int IdProfesor { get; set; }
        public int IdEstudiante { get; set; }
        //Propiedades de navegacion
        public ProfesorModel Profesor { get; set; }
        public EstudianteModel Estudiante { get; set; }
    }
}
