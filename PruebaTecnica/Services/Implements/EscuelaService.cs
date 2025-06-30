using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.DTOs;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Services.Interfaces
{
    public class EscuelaService : IEscuelaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EscuelaService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Insertmaos
        public async Task AddAsync(string nombre, string descripcion) { 
            await _context.Database.ExecuteSqlInterpolatedAsync($"Exec Sp_CRUD_Escuela @Accion={1}, @Nombre={nombre}, @Descripcion={descripcion}");
        }
        //Listamos
        public async Task<List<EscuelaDTO>> GetAllAsync()
        {
            var escuelas = await _context.Escuelas.FromSqlInterpolated($"Exec Sp_CRUD_Escuela @Accion={2}")
                .ToListAsync();
            var resultado = _mapper.Map<List<EscuelaDTO>>(escuelas);
            return resultado;
        }
        //Listamos por Id
        public async Task<EscuelaDTO> GetByIdAsync(int id)
        {
            var escuela = _context.Escuelas
                .FromSqlInterpolated($"EXEC Sp_CRUD_Escuela @Accion={3}, @Id={id}")
                .AsEnumerable()
                .FirstOrDefault();

            return escuela == null ? null : _mapper.Map<EscuelaDTO>(escuela);
        }
        //Actualizamos
        public async Task<bool> UpdateAsync(int id, string nombre, string descripcion, bool activo)
        {
            var result = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC Sp_CRUD_Escuela @Accion={4}, @Id={id}, @Nombre={nombre}, @Descripcion={descripcion}, @Activo={activo}");

            return result > 0;
        }

        //Eliminamos
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC Sp_CRUD_Escuela @Accion={5}, @Id={id}");

            return result > 0;
        }
    }
}
