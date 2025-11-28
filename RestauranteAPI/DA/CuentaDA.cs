using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class CuentaDA : ICuentaDA
    {
        private readonly IRepositorioDapper _repositorioDapper;
        private readonly SqlConnection _sqlConnection;

        public CuentaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Abrir(CuentaRequest cuenta)
        {
            string query = @"AbrirCuenta";
            var id = Guid.NewGuid();

            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = id,
                NombreCliente = cuenta.NombreCliente,
                NumeroMesa = cuenta.NumeroMesa
            });

            return resultado;
        }

        public async Task<Guid> Cerrar(Guid Id)
        {
            string query = @"CerrarCuenta";

            var resultado = await _sqlConnection
                .ExecuteScalarAsync<Guid>(query, new { Id });

            return resultado;
        }

        public async Task<IEnumerable<CuentaResponse>> Obtener()
        {
            string query = @"ObtenerCuentas";

            var resultado = await _sqlConnection
                .QueryAsync<CuentaResponse>(query);

            return resultado;
        }

        public async Task<CuentaResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerCuenta";

            var resultado = await _sqlConnection
                .QueryAsync<CuentaResponse>(query, new { Id });

            return resultado.FirstOrDefault();
        }
    }
}
