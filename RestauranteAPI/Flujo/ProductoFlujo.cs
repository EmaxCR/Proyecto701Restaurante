using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;


namespace Flujo
{
    public class ProductoFlujo : IProductoFlujo
    {

        private IProductoDA _productoDA;
        private IFinanciaServicio _financia;
        public ProductoFlujo(IProductoDA productoDA, IFinanciaServicio financia)
        {
            _productoDA = productoDA;
            _financia = financia;
        }

        public async Task<Guid> Agregar(ProductoRequest producto)
        {
            return await _productoDA.Agregar(producto);
        }

        public async Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            return await _productoDA.Editar(Id, producto);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _productoDA.Eliminar(Id);
        }

        public async Task<IEnumerable<ProductoResponse>> Obtener()
        {
            return await _productoDA.Obtener();
        }

        public async Task<ProductoDetalle> Obtener(Guid Id)
        {
           var producto = await _productoDA.Obtener(Id);
            /*
                        var precioDolar = await _financia.Obtener();
                        producto.PrecioDolar = ( producto.Precio / precioDolar.Valor);
            /            */
            return producto;
        }
    }
}
