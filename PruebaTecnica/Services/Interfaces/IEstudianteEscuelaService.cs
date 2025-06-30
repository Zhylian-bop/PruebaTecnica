using PruebaTecnica.DTOs;

namespace PruebaTecnica.Services.Servicios
{
    public interface IEstudianteEscuelaService
    {
        Task AddAsync(int estudianteId, int escuelaId);
        Task<List<EstudianteEscuelaDTO>> GetAllAsync();
        Task<EstudianteEscuelaDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, int estudianteId, int escuelaId);
        Task<bool> DeleteAsync(int id);
    }
}
