using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class SubCategoriaFlujo : ISubCategoriaFlujo
    {

        private  ISubCategoriaDA _subCategoriaDA;

        public SubCategoriaFlujo(ISubCategoriaDA subCategoriaDA)
        {
            _subCategoriaDA = subCategoriaDA;
        }

        public Task<Guid> Agregar(SubCategoriaRequest subCategoria)
        {
            return _subCategoriaDA.Agregar(subCategoria);
        }

        public Task<Guid> Editar(Guid Id, SubCategoriaRequest subCategoria)
        {
           return _subCategoriaDA.Editar(Id, subCategoria);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
           return _subCategoriaDA.Eliminar(Id);
        }

        public Task<IEnumerable<SubCategoriaResponse>> Obtener()
        {
           return _subCategoriaDA.Obtener();
        }

        public Task<SubCategoriaResponse> Obtener(Guid Id)
        {
          return _subCategoriaDA.Obtener(Id);
        }
    }
}
