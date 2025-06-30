using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Services.Servicios;

namespace PruebaTecnica.Controllers
{
    [Route("api/v1/profesores")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;
        public ProfesorController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }
        //Insertamos un profesor
        [HttpPost]
        public async Task<IActionResult> AddAsync(string nombre, string apellido, int escuelaId)
        {
            try 
            {
                await _profesorService.AddAsync(nombre, apellido, escuelaId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al agregar el profesor: {ex.Message}");
            }
            
        }
        //Listamos todos los profesores
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try {
                var profesores = await _profesorService.GetAllAsync();
                return Ok(profesores);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los profesores: {ex.Message}");
            }
            
        }
        //Obtenemos un profesor por Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var profesor = await _profesorService.GetByIdAsync(id);
            if (profesor == null)
                return NotFound();
            return Ok(profesor);
        }
        //Actualizamos un profesor
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, string nombre, string apellido, int escuelaId, bool activo)
        {
            try {
                var result = await _profesorService.UpdateAsync(id, nombre, apellido, escuelaId, activo);

                return Ok("Profesor Actualizado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el profesor: {ex.Message}");
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try {
                var result = await _profesorService.DeleteAsync(id);
                return Ok("Profesor ELiminado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el profesor: {ex.Message}");
            }
            
        }
    }
}
