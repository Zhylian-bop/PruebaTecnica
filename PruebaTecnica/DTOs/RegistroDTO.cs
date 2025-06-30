using System.ComponentModel;

namespace PruebaTecnica.DTOs
{
    public class RegistroDTO
    {
        public bool Activo { get; set; } = true;
        [DefaultValue(false)]
        public bool Borrado { get; set; } = false;
        public DateTime AltaSistema { get; set; } = DateTime.Now;
    }
}
