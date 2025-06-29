namespace PruebaTecnica.Models
{
    public class AlumnoEscuelaModel:RegistroModel
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public int IdEscuela { get; set; }
    }
}
