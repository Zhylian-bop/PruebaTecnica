namespace PruebaTecnica.DTOs
{
    public class RegistroDTO
    {
        public bool Activo { get; set; } = true;
        public bool Borrado { get; set; } = false;
        public DateTime AltaSistema { get; set; } = DateTime.Now;
    }
}
