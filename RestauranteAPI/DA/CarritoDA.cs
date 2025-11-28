using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class CarritoDA : ICarritoDA
    {
        private readonly IRepositorioDapper _repositorioDapper;
        private readonly SqlConnection _sqlConnection;

        public CarritoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones

        public async Task<Guid> Agregar(CarritoRequest carrito)
        {
            string query = @"AgregarCarrito";

            var resultadoConsulta = await _sqlConnection
                .ExecuteScalarAsync<Guid>(query, new
                {
                    Id = Guid.NewGuid(),
                    IdCuenta = carrito.IdCuenta,
                    IdProducto = carrito.IdProducto,
                    Cantidad = carrito.Cantidad
                    
                });

            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, CarritoRequest carrito)
        {
            await VerificarCarritoExiste(Id);

            string query = @"EditarCarrito";

            var resultadoConsulta = await _sqlConnection
                .ExecuteScalarAsync<Guid>(query, new
                {
                    Id = Id,
                    IdCuenta = carrito.IdCuenta,
                    IdProducto = carrito.IdProducto,
                    Cantidad = carrito.Cantidad
                });

            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarCarritoExiste(Id);

            string query = @"EliminarCarrito";

            var resultadoConsulta = await _sqlConnection
                .ExecuteScalarAsync<Guid>(query, new
                {
                    Id = Id
                });

            return resultadoConsulta;
        }

        public async Task<IEnumerable<CarritoResponse>> Obtener()
        {
            string query = @"ObtenerCarritos";

            var resultadoConsulta = await _sqlConnection
                .QueryAsync<CarritoResponse>(query);

            return resultadoConsulta;
        }

        public async Task<CarritoResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerCarrito";

            var resultadoConsulta = await _sqlConnection
                .QueryAsync<CarritoResponse>(query, new { Id });

            return resultadoConsulta.FirstOrDefault();
        }

        private async Task VerificarCarritoExiste(Guid Id)
        {
            CarritoResponse resultado = await Obtener(Id);
            if (resultado == null)
                throw new Exception("El carrito no existe");
        }

        public async Task<IEnumerable<CarritoResponse>> ObtenerPorCuenta(Guid IdCuenta)
        {
            string query = @"ObtenerCarritoPorCuenta";

            var resultadoConsulta = await _sqlConnection
                .QueryAsync<CarritoResponse>(query, new { IdCuenta });

            return resultadoConsulta;
        }
        #endregion
    }
}
