using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface ISubCategoriaFlujo
    {

        Task<IEnumerable<SubCategoriaResponse>> Obtener();

        Task<SubCategoriaResponse> Obtener(Guid Id);

        Task<Guid> Agregar(SubCategoriaRequest subCategoria);

        Task<Guid> Editar(Guid Id, SubCategoriaRequest subCategoria);

        Task<Guid> Eliminar(Guid Id);


    }
}
