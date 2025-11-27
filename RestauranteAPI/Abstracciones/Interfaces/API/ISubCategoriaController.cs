using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
namespace Abstracciones.Interfaces.API
{
    public  interface ISubCategoriaController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(SubCategoriaRequest subCategoria);
        Task<IActionResult> Editar(Guid Id, SubCategoriaRequest subCagetoria);
        Task<IActionResult> Eliminar(Guid Id);
    }
}
