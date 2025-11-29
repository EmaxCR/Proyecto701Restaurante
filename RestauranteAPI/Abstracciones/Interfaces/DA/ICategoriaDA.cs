using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface ICategoriaDA
    {
        Task<IEnumerable<CategoriaResponse>> Obtener();

        Task<CategoriaResponse> Obtener(Guid Id);

        Task<Guid> Agregar(Categoria categoria);

        Task<Guid> Editar(Guid Id, Categoria categoria);

        Task<Guid> Eliminar(Guid Id);

    }
}
