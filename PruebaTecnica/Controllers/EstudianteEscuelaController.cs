using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Controllers
{
    [Route("api/v1/estudianteescuelas")]
    [ApiController]
    public class EstudianteEscuelaController : ControllerBase
    {
        private readonly IEstudianteEscuelaService _estudianteEscuelaService;
        public EstudianteEscuelaController(IEstudianteEscuelaService estudianteEscuelaService)
        {
            _estudianteEscuelaService = estudianteEscuelaService;
        }
        //Insertamos
        [HttpPost]
        public async Task<IActionResult> AddAsync(int estudianteId, int escuelaId)
        {
            try
            {
                await _estudianteEscuelaService.AddAsync(estudianteId, escuelaId);
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
                var estudianteEscuelas = await _estudianteEscuelaService.GetAllAsync();
                return Ok(estudianteEscuelas);
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
                var estudianteEscuela = await _estudianteEscuelaService.GetByIdAsync(id);
                if (estudianteEscuela == null)
                {
                    return NotFound($"Registro con ID {id} no encontrado.");
                }
                return Ok(estudianteEscuela);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el registro: {ex.Message}");
            }
        }
        //PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, int estudianteId, int escuelaId)
        {
            try
            {
                var result = await _estudianteEscuelaService.UpdateAsync(id, estudianteId, escuelaId);
                if (result)
                {
                    return Ok("Registro actualizado correctamente.");
                }
                return NotFound($"Registro con ID {id} no encontrado.");
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
                var result = await _estudianteEscuelaService.DeleteAsync(id);
                if (result)
                {
                    return Ok("Registro eliminado correctamente.");
                }
                return NotFound($"Registro con ID {id} no encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el registro: {ex.Message}");
            }
        }
    }
}
