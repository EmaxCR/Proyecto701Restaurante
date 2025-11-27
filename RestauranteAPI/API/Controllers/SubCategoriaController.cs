using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using DA;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase, ISubCategoriaController
    {

        private ISubCategoriaFlujo _subCategoriaFlujo;
        private ILogger<SubCategoriaController> _logger;

        public SubCategoriaController(ISubCategoriaFlujo subCategoriaFlujo, ILogger<SubCategoriaController> logger)
        {
            _subCategoriaFlujo = subCategoriaFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(SubCategoriaRequest subCategoria)
        {
            var resultado = await _subCategoriaFlujo.Agregar(subCategoria);
            return Ok(resultado);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, SubCategoriaRequest subCategoria)
        {
            var resultado = await _subCategoriaFlujo.Editar(Id, subCategoria);
            return Ok(resultado);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            var resultado = await _subCategoriaFlujo.Eliminar(Id);
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _subCategoriaFlujo.Obtener();
            return Ok(resultado);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            var resultado = await _subCategoriaFlujo.Obtener(Id);
            return Ok(resultado);
        }
    }
}
