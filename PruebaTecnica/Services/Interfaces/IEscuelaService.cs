using PruebaTecnica.DTOs;

namespace PruebaTecnica.Services.Servicios
{
    public interface IEscuelaService
    {
        Task AddAsync(string nombre, string descripcion);
        Task<List<EscuelaDTO>> GetAllAsync();
        Task<EscuelaDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, string nombre, string descripcion, bool activo);
        Task<bool> DeleteAsync(int id);
    }
}
