using PruebaTecnica.DTOs;

namespace PruebaTecnica.Services.Servicios
{
    public interface IProfesorService
    {
        Task AddAsync(string nombre, string apellido, int escuelaId);
        Task<List<ProfesorDTO>> GetAllAsync();
        Task<ProfesorDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, string nombre, string apellido, int escuelaId, bool activo);
        Task<bool> DeleteAsync(int id);
    }
}
