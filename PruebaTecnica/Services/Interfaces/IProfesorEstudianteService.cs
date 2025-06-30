using PruebaTecnica.DTOs;

namespace PruebaTecnica.Services.Servicios
{
    public interface IProfesorEstudianteService
    {
        Task AddAsync(int profesorId, int estudianteId);
        Task<List<ProfesorEstudianteDTO>> GetAllAsync();
        Task<ProfesorEstudianteDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, int profesorId, int estudianteId);
        Task<bool> DeleteAsync(int id);
    }
}
