using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface ICarritoFlujo
    {
        Task<IEnumerable<CarritoResponse>> Obtener();
        Task<CarritoResponse> Obtener(Guid Id);
        Task<Guid> Agregar(CarritoRequest carrito);
        Task<Guid> Editar(Guid Id, CarritoRequest carrito);
        Task<Guid> Eliminar(Guid Id);
        Task<IEnumerable<CarritoResponse>> ObtenerPorCuenta(Guid IdCuenta);
       
    }
}
