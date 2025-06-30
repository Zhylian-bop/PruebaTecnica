using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTOs;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Controllers
{
    [Route("api/v1/estudiantes")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;
        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }
        //POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstudianteDTO dto)
        {
            try {
                await _estudianteService.AddAsync(dto.Nombre, dto.Apellido, dto.FechaNacimiento);
                return Ok("Estudiante creado correctamente.");
            } catch(Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear el estudiante: {ex.Message}");
            }
        }
        //GET general
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var estudiantes = await _estudianteService.GetAllAsync();
                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los estudiantes: {ex.Message}");
            }
        }
        //GET por Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var estudiantes = await _estudianteService.GetByIdAsync(id);
                if (estudiantes == null || !estudiantes.Any())
                {
                    return NotFound($"Estudiante con ID {id} no encontrado.");
                }
                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el estudiante: {ex.Message}");
            }
        }
        //PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstudianteDTO dto)
        {
            try
            {
                var result = await _estudianteService.UpdateAsync(id, dto.Nombre, dto.Apellido, dto.FechaNacimiento, dto.Activo);
                return Ok("Estudiante actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el estudiante: {ex.Message}");
            }
        }
        //DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _estudianteService.DeleteAsync(id);

                return Ok("Estudiante eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el estudiante: {ex.Message}");
            }
        }
        }
}
