using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Controllers
{
    [Route("api/v1/profesorestudiantes")]
    [ApiController]
    public class ProfesorEstudiantesController : ControllerBase
    {
        private readonly IProfesorEstudianteService _profesorEstudianteService;
        public ProfesorEstudiantesController(IProfesorEstudianteService profesorEstudianteService)
        {
            _profesorEstudianteService = profesorEstudianteService;
        }
        //Insertamos
        [HttpPost]
        public async Task<IActionResult> AddAsync(int profesorId, int estudianteId)
        {
            try
            {
                await _profesorEstudianteService.AddAsync(profesorId, estudianteId);
                return Ok("Registro creado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear el registro: {ex.Message}");
            }
        }
        //GET general
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var profesorEstudiantes = await _profesorEstudianteService.GetAllAsync();
                return Ok(profesorEstudiantes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los registros: {ex.Message}");
            }
        }
        //GET por Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var profesorEstudiante = await _profesorEstudianteService.GetByIdAsync(id);
                if (profesorEstudiante == null)
                {
                    return NotFound($"Registro con ID {id} no encontrado.");
                }
                return Ok(profesorEstudiante);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el registro: {ex.Message}");
            }
        }
        //PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, int profesorId, int estudianteId)
        {
            try
            {
                var result = await _profesorEstudianteService.UpdateAsync(id, profesorId, estudianteId);
                return Ok("Registro actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el registro: {ex.Message}");
            }
        }
        //DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _profesorEstudianteService.DeleteAsync(id);
                return Ok("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el registro: {ex.Message}");
            }
        }
    }
}
