using PruebaTecnica.DTOs;

namespace PruebaTecnica.Services.Servicios
{
    public interface IEstudianteService
    {
        Task AddAsync(string nombre, string apellido, DateTime fechaNacimiento);
        Task<List<EstudianteDTO>> GetAllAsync();
        Task<List<EstudianteDTO>> GetByIdAsync(int Id);
        Task<bool> UpdateAsync(int id, string nombre, string apellido, DateTime fechaNacimiento, bool activo);
        Task<bool> DeleteAsync(int id);
    }
}
