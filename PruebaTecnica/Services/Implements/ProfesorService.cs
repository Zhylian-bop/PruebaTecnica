using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.DTOs;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Services.Interfaces
{
    public class ProfesorService : IProfesorService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProfesorService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        //Insertamos
        public async Task AddAsync(string nombre, string apellido, int escuelaId)
        { 
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"Exec Sp_CRUD_Profesores @Accion={1},@Nombre={nombre},@Apellido={apellido},@EscuelaId={escuelaId}");
        }
        //Listamos general
        public async Task<List<ProfesorDTO>> GetAllAsync()
        {
            var profesores = await _dbContext.Profesores.FromSqlInterpolated($"Exec Sp_CRUD_Profesores @Accion={2}")
                .ToListAsync();
            var resultado = _mapper.Map<List<ProfesorDTO>>(profesores);
            return resultado;
        }
        //Buscamos por Id
        public async Task<ProfesorDTO> GetByIdAsync(int id)
        {
            var profesor = _dbContext.Profesores
                .FromSqlInterpolated($"EXEC Sp_CRUD_Profesores @Accion={3}, @Id={id}")
                .AsEnumerable()
                .FirstOrDefault();
            return profesor == null ? null : _mapper.Map<ProfesorDTO>(profesor);
        }
        //Actualizamos
        public async Task<bool> UpdateAsync(int id, string nombre, string apellido, int escuelaId, bool activo)
        {
            var resultado = await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC Sp_CRUD_Profesores @Accion={4}, @Id={id}, @Nombre={nombre}, @Apellido={apellido}, @EscuelaId={escuelaId}, @Activo={activo}");
            return resultado > 0;
        }
        //Eliminamos
        public async Task<bool> DeleteAsync(int id)
        {
            var resultado = await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC Sp_CRUD_Profesores @Accion={5}, @Id={id}");
            return resultado > 0;
        }
        }
}
