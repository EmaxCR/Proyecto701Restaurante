using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface ICarritoController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(CarritoRequest carrito);
        Task<IActionResult> Editar(Guid Id, CarritoRequest carrito);
        Task<IActionResult> Eliminar(Guid Id);
        
    }
}

