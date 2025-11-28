using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class FacturaDA : IFacturaDA
    {
        private readonly IRepositorioDapper _repositorioDapper;
        private readonly SqlConnection _sqlConnection;

        public FacturaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorio();
        }

        public async Task<int> AgregarFactura(FacturaResponse factura)
        {
            const string query = @"AgregarFactura";

            var numeroFactura = await _sqlConnection
                .ExecuteScalarAsync<int>(query, new
                {
                    Id = factura.Id,
                    IdCuenta = factura.IdCuenta,
                    NombreCliente = factura.NombreCliente,
                    NumeroMesa = factura.NumeroMesa,
                    Subtotal = factura.Subtotal,
                    Impuesto = factura.Impuesto,
                    Servicio = factura.Servicio,
                    TotalFinal = factura.TotalFinal
                });

            return numeroFactura;
        }

        public async Task AgregarDetalle(Guid idFactura, FacturaItem item)
        {
            const string query = @"AgregarFacturaDetalle";

            await _sqlConnection.ExecuteAsync(query, new
            {
                Id = Guid.NewGuid(),
                IdFactura = idFactura,
                NombreProducto = item.NombreProducto,
                Cantidad = item.Cantidad,
                PrecioUnitario = item.PrecioUnitario,
                TotalLinea = item.TotalLinea
            });
        }
    }
}
