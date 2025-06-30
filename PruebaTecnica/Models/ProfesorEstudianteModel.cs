namespace PruebaTecnica.Models
{
    public class ProfesorEstudianteModel : RegistroModel
    {
        public int Id { get; set; }
        public int ProfesorId { get; set; }
        public int EstudianteId { get; set; }
        //Propiedades de navegacion
        public ProfesorModel Profesor { get; set; }
        public EstudianteModel Estudiante { get; set; }
    }
}
