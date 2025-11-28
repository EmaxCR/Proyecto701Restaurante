using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : ControllerBase, ICarritoController
    {
        private readonly ICarritoFlujo _carritoFlujo;

        public CarritoController(ICarritoFlujo carritoFlujo)
        {
            _carritoFlujo = carritoFlujo;
        }

        // GET todos
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var items = await _carritoFlujo.Obtener();

            var resultado = items.Select(i => new
            {
                i.Id,
                i.NombreProducto,
                i.DescripcionProducto,
                i.Cantidad,
                i.PrecioProducto,
                i.TotalLinea
            });

            return Ok(resultado);
        }

        // GET id 
        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            var item = await _carritoFlujo.Obtener(Id);
            if (item == null)
                return NotFound();

            var resultado = new
            {
                item.Id,
                item.NombreProducto,
                item.DescripcionProducto,
                item.Cantidad,
                item.PrecioProducto,
                item.TotalLinea
            };

            return Ok(resultado);
        }

        // POST 
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] CarritoRequest carrito)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _carritoFlujo.Agregar(carrito);

            return Ok(new
            {
                mensaje = "Producto añadido al carrito",
                id
            });
        }

        // PUT 
        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, [FromBody] CarritoRequest carrito)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _carritoFlujo.Editar(Id, carrito);

            return Ok(new
            {
                mensaje = "Carrito actualizado",
                id = resultado
            });
        }

        // DELETE 
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            var resultado = await _carritoFlujo.Eliminar(Id);

            return Ok(new
            {
                mensaje = "Producto eliminado del carrito",
                id = resultado
            });
        }
    }
}
