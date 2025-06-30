using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTOs;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Controllers
{
    [Route("api/v1/escuelas")]
    [ApiController]
    public class EscuelaController : ControllerBase
    {
        private readonly IEscuelaService _escuelaService;
        public EscuelaController(IEscuelaService escuelaService)
        {
            _escuelaService = escuelaService;
        }
        //POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EscuelaDTO dto) { 
            await _escuelaService.AddAsync(dto.Nombre, dto.Descripcion);
            return Ok("Escuela creada correctamente.");
        }

        //GET general
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var escuelas = await _escuelaService.GetAllAsync();
                return Ok(escuelas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las escuelas: {ex.Message}");
            }
        }
        //GET por Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var escuela = await _escuelaService.GetByIdAsync(id);
                if (escuela == null)
                {
                    return NotFound($"Escuela con ID {id} no encontrada.");
                }
                return Ok(escuela);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la escuela: {ex.Message}");
            }
        }
        //PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EscuelaDTO dto)
        {
            try
            {
                var updatedEscuela = await _escuelaService.UpdateAsync(id, dto.Nombre, dto.Descripcion, dto.Activo);
                if (updatedEscuela == null)
                {
                    return NotFound($"Escuela con ID {id} no encontrada.");
                }
                return Ok(updatedEscuela);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la escuela: {ex.Message}");
            }
        }
        //DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _escuelaService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound($"Escuela con ID {id} no encontrada.");
                }
                return Ok($"Escuela con ID {id} eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la escuela: {ex.Message}");
            }
        }
    }
}
