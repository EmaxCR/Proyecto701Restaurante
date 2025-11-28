using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase, ICuentaController
    {
        private readonly ICuentaFlujo _cuentaFlujo;
        private readonly ICarritoFlujo _carritoFlujo;

        public CuentaController(ICuentaFlujo cuentaFlujo, ICarritoFlujo carritoFlujo)
        {
            _cuentaFlujo = cuentaFlujo;
            _carritoFlujo = carritoFlujo;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var cuentas = await _cuentaFlujo.Obtener();
            return Ok(cuentas);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            var cuenta = await _cuentaFlujo.Obtener(Id);
            if (cuenta == null)
                return NotFound();

            var items = await _carritoFlujo.ObtenerPorCuenta(Id);
            var totalGeneral = items.Sum(i => i.TotalLinea);

            var resultado = new
            {
                cuenta.Id,
                cuenta.NumeroCuenta,
                cuenta.NombreCliente,
                cuenta.NumeroMesa,
                cuenta.FechaApertura,
                cuenta.Estado,
                totalGeneral,
                items = items.Select(i => new
                {
                    i.Id,
                    i.NombreProducto,
                    i.Cantidad,
                    i.PrecioProducto,
                    i.TotalLinea
                })
            };

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Abrir([FromBody] CuentaRequest cuenta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (cuenta.FechaApertura == default)
                cuenta.FechaApertura = DateTime.Now;

            if (string.IsNullOrWhiteSpace(cuenta.Estado))
                cuenta.Estado = "Abierta";

            var id = await _cuentaFlujo.Abrir(cuenta);
            return Ok(new { mensaje = "Cuenta abierta", id });
        }

        [HttpPut("{Id}/Cerrar")]
        public async Task<IActionResult> Cerrar(Guid Id)
        {
            var factura = await _cuentaFlujo.Cerrar(Id);

            // devolver factura 
            return Ok(new
            {
                mensaje = "Cuenta cerrada y factura generada",
                factura
            });
        }
        }
}
