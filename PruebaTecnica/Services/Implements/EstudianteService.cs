using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.DTOs;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Services.Interfaces
{
    public class EstudianteService:IEstudianteService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public EstudianteService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        // Aquí puedes implementar los métodos necesarios para el servicio de estudiantes

        //Insertamos
        public async Task AddAsync(string nombre, string apellido, DateTime fechaNacimiento)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"Exec Sp_CRUD_Estudiante @Accion={1}, @Nombre={nombre}, @Apellido={apellido}, @FechaNacimiento={fechaNacimiento}");
        }
        //Listado general
        public async Task<List<EstudianteDTO>> GetAllAsync()
        {
            var estudiantes = await _dbContext.Estudiantes.FromSqlInterpolated($"Exec Sp_CRUD_Estudiante @Accion={2}")
                .ToListAsync();
            var resultado = _mapper.Map<List<EstudianteDTO>>(estudiantes);
            return resultado;
        }
        //Listado por Id
        public async Task<List<EstudianteDTO>> GetByIdAsync(int Id)
        {
            var estudiantes = await _dbContext.Estudiantes.FromSqlInterpolated($"Exec Sp_CRUD_Estudiante @Accion={3}, @Id={Id}")
                .ToListAsync();
            var resultado = _mapper.Map<List<EstudianteDTO>>(estudiantes);
            return resultado;
        }
        //Actualizamos
        public async Task<bool> UpdateAsync(int id, string nombre, string apellido, DateTime fechaNacimiento, bool activo) { 
            var resultado= await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC Sp_CRUD_Estudiante @Accion={4}, @Id={id}, @Nombre={nombre}, @Apellido={apellido}, @FechaNacimiento={fechaNacimiento}, @Activo={activo}");
            return resultado > 0;
        }
        //Eliminamos
        public async Task<bool> DeleteAsync(int id)
        {
            var resultado = await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC Sp_CRUD_Estudiante @Accion={5}, @Id={id}");
            return resultado > 0;
        }
    }
}
