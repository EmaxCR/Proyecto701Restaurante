using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class CuentaFlujo : ICuentaFlujo
    {
        private readonly ICuentaDA _cuentaDA;
        private readonly ICarritoDA _carritoDA;
        private readonly IFacturaDA _facturaDA;

        public CuentaFlujo(
            ICuentaDA cuentaDA,
            ICarritoDA carritoDA,
            IFacturaDA facturaDA)
        {
            _cuentaDA = cuentaDA;
            _carritoDA = carritoDA;
            _facturaDA = facturaDA;
        }

        public Task<IEnumerable<CuentaResponse>> Obtener()
        {
            return _cuentaDA.Obtener();
        }

        public Task<CuentaResponse> Obtener(Guid Id)
        {
            return _cuentaDA.Obtener(Id);
        }

        public Task<Guid> Abrir(CuentaRequest cuenta)
        {
            return _cuentaDA.Abrir(cuenta);
        }

        public async Task<FacturaResponse> Cerrar(Guid Id)
        {
            //  se verifica que la cuenta exite
            var cuenta = await _cuentaDA.Obtener(Id);
            if (cuenta == null)
                throw new Exception("La cuenta no existe.");

            if (!string.Equals(cuenta.Estado, "Abierta", StringComparison.OrdinalIgnoreCase))
                throw new Exception("La cuenta ya está cerrada.");

            //obtener los productos por cuenta
            var itemsCarrito = await _carritoDA.ObtenerPorCuenta(Id);
            if (itemsCarrito == null || !itemsCarrito.Any())
                throw new Exception("La cuenta no tiene productos.");

            // calcular el total
            decimal subtotal = itemsCarrito.Sum(i => i.TotalLinea);
            decimal impuesto = Math.Round(subtotal * 0.13m, 2);
            decimal servicio = Math.Round(subtotal * 0.10m, 2);
            decimal totalFinal = subtotal + impuesto + servicio;

            // la factura
            var factura = new FacturaResponse
            {
                Id = Guid.NewGuid(),
                IdCuenta = cuenta.Id,
                NombreCliente = cuenta.NombreCliente,
                NumeroMesa = cuenta.NumeroMesa ??0,
                Fecha = DateTime.Now,
                Subtotal = subtotal,
                Impuesto = impuesto,
                Servicio = servicio,
                TotalFinal = totalFinal,
                Items = itemsCarrito.Select(i => new FacturaItem
                {
                    NombreProducto = i.NombreProducto,
                    Cantidad = i.Cantidad,
                    PrecioUnitario = i.PrecioProducto,
                    TotalLinea = i.TotalLinea
                }).ToList()
            };

            // se guarda la factura
            int numeroFactura = await _facturaDA.AgregarFactura(factura);
            factura.NumeroFactura = numeroFactura;

            // detalle
            foreach (var item in factura.Items)
            {
                await _facturaDA.AgregarDetalle(factura.Id, item);
            }

            // se cierra la cuenta
            await _cuentaDA.Cerrar(Id);

            return factura;
        }
    }
}
