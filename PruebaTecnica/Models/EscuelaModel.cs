namespace PruebaTecnica.Models
{
    public class EscuelaModel : RegistroModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        // Relaciones
        public IEnumerable<AlumnoEscuelaModel> AlumnoEscuelas { get; set; }
        public IEnumerable<ProfesoresModel> Profesores { get; set; }
    }
}
