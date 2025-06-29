namespace PruebaTecnica.Models
{
    public class RegistroModel
    {
        public bool Activo { get; set; } = true;
        public bool Borrado { get; set; } = false;
        public DateTime AltaSistema { get; set; } = DateTime.Now;
    }
}
