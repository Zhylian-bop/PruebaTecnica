using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.DTOs;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Services.Interfaces
{
    public class EstudianteEscuelaService :IEstudianteEscuelaService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public EstudianteEscuelaService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        // Insertamos
        public async Task AddAsync(int estudianteId, int escuelaId)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"Exec Sp_CRUD_EstudianteEscuela @Accion={1}, @EstudianteId={estudianteId}, @EscuelaId={escuelaId}");
        }
        // Listamos todos los registros
        public async Task<List<EstudianteEscuelaDTO>> GetAllAsync()
        {
            var estudianteEscuelas = await _dbContext.EstudianteEscuelas.FromSqlInterpolated($"Exec Sp_CRUD_EstudianteEscuela @Accion={2}")
                .ToListAsync();
            var resultado = _mapper.Map<List<EstudianteEscuelaDTO>>(estudianteEscuelas);
            return resultado;
        }
        // Obtenemos por Id
        public async Task<EstudianteEscuelaDTO> GetByIdAsync(int id)
        {
            var estudianteEscuela = _dbContext.EstudianteEscuelas
                .FromSqlInterpolated($"EXEC Sp_CRUD_EstudianteEscuela @Accion={3}, @Id={id}")
                .AsEnumerable()
                .FirstOrDefault();
            return estudianteEscuela == null ? null : _mapper.Map<EstudianteEscuelaDTO>(estudianteEscuela);
        }
        // Actualizamos
        public async Task<bool> UpdateAsync(int id, int estudianteId, int escuelaId)
        {
            try {
                var resultado = await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                    $"EXEC Sp_CRUD_EstudianteEscuela @Accion={4}, @Id={id}, @EstudianteId={estudianteId}, @EscuelaId={escuelaId}");
                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el registro: {ex.Message}");
            }
            
        }
        // Eliminamos
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var resultado = await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                    $"EXEC Sp_CRUD_EstudianteEscuela @Accion={5}, @Id={id}");
                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el registro: {ex.Message}");
            }
        }
    }
}
