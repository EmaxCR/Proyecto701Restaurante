using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class CategoriaFlujo : ICategoriaFlujo
    {

        private ICategoriaDA _categoriaDA;

        public CategoriaFlujo(ICategoriaDA categoriaDA)
        {
            _categoriaDA = categoriaDA;
        }

        public Task<Guid> Agregar(Categoria categoria)
        {
            return _categoriaDA.Agregar(categoria);
        }

        public Task<Guid> Editar(Guid Id, Categoria categoria)
        {
            return _categoriaDA.Editar(Id, categoria);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            return _categoriaDA.Eliminar(Id);
        }

        public Task<IEnumerable<CategoriaResponse>> Obtener()
        {
            return _categoriaDA.Obtener();
        }

        public Task<CategoriaResponse> Obtener(Guid Id)
        {
            return _categoriaDA.Obtener(Id);
        }
    }
}
