using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface ISubCategoriaDA
    {
        Task<IEnumerable<SubCategoriaResponse>> Obtener();

        Task<SubCategoriaResponse> Obtener(Guid Id);

        Task<Guid> Agregar(SubCategoriaRequest subCategoria);

        Task<Guid> Editar(Guid Id, SubCategoriaRequest subCategoria);

        Task<Guid> Eliminar(Guid Id);

    }
}
