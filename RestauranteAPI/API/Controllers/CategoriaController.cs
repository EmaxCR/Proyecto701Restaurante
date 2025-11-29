using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using DA;
using Flujo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase, ICategoriaController
    {

        private ICategoriaFlujo _categoriaFlujo;
        private ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaFlujo categoriaFlujo, ILogger<CategoriaController> logger)
        {
            _categoriaFlujo = categoriaFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Categoria categoria)
        {
            {
                var resultado = await _categoriaFlujo.Agregar(categoria);
                return Ok(resultado);
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, Categoria categoria)
        {
            var resultado = await _categoriaFlujo.Editar(Id, categoria);
            return Ok(resultado);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            var resultado = await _categoriaFlujo.Eliminar(Id);
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _categoriaFlujo.Obtener();
            return Ok(resultado);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            var resultado = await _categoriaFlujo.Obtener(Id);
            return Ok(resultado);
        }
    }
}
