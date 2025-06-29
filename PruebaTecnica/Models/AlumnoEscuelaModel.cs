namespace PruebaTecnica.Models
{
    public class AlumnoEscuelaModel:RegistroModel
    {
        public int Id { get; set; }
        public int IdEstudiante { get; set; }
        public int IdEscuela { get; set; }
        //propiedades de navegacion
        public EstudianteModel Estudiante { get; set; }
        public EscuelaModel Escuela { get; set; }
    }
}
