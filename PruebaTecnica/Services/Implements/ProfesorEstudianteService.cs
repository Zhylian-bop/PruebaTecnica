using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.DTOs;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Services.Interfaces
{
    public class ProfesorEstudianteService : IProfesorEstudianteService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProfesorEstudianteService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        // Insertamos
        public async Task AddAsync(int profesorId, int estudianteId)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"Exec Sp_CRUD_ProfesorEstudiante @Accion={1}, @ProfesorId={profesorId}, @EstudianteId={estudianteId}");
        }
        // Listamos todos los registros
        public async Task<List<ProfesorEstudianteDTO>> GetAllAsync()
        {
            var profesorEstudiantes = await _dbContext.ProfesorEstudiante.FromSqlInterpolated($"Exec Sp_CRUD_ProfesorEstudiante @Accion={2}")
                .ToListAsync();
            var resultado = _mapper.Map<List<ProfesorEstudianteDTO>>(profesorEstudiantes);
            return resultado;
        }
        // Obtenemos por Id
        public async Task<ProfesorEstudianteDTO> GetByIdAsync(int id)
        {
            var profesorEstudiante = _dbContext.ProfesorEstudiante
                .FromSqlInterpolated($"EXEC Sp_CRUD_ProfesorEstudiante @Accion={3}, @Id={id}")
                .AsEnumerable()
                .FirstOrDefault();
            return profesorEstudiante == null ? null : _mapper.Map<ProfesorEstudianteDTO>(profesorEstudiante);
        }
        // Actualizamos
        public async Task<bool> UpdateAsync(int id, int profesorId, int estudianteId)
        {
            try
            {
                var resultado = await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                    $"EXEC Sp_CRUD_ProfesorEstudiante @Accion={4}, @Id={id}, @ProfesorId={profesorId}, @EstudianteId={estudianteId}");
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
                    $"EXEC Sp_CRUD_ProfesorEstudiante @Accion={5}, @Id={id}");
                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el registro: {ex.Message}");
            }
        }
    }
}
