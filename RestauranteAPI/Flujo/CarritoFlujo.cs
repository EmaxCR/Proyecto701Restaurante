using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class CarritoFlujo : ICarritoFlujo
    {
        private readonly ICarritoDA _carritoDA;

        public CarritoFlujo(ICarritoDA carritoDA)
        {
            _carritoDA = carritoDA;
        }

        public Task<IEnumerable<CarritoResponse>> Obtener()
        {
            return _carritoDA.Obtener();
        }

        public Task<CarritoResponse> Obtener(Guid Id)
        {
            return _carritoDA.Obtener(Id);
        }

        public Task<Guid> Agregar(CarritoRequest carrito)
        {
            return _carritoDA.Agregar(carrito);
        }

        public Task<Guid> Editar(Guid Id, CarritoRequest carrito)
        {
            return _carritoDA.Editar(Id, carrito);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            return _carritoDA.Eliminar(Id);
        }
        public Task<IEnumerable<CarritoResponse>> ObtenerPorCuenta(Guid IdCuenta)
        {
            return _carritoDA.ObtenerPorCuenta(IdCuenta);
        }



    }
}
