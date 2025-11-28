using Abstracciones.Modelos;
using System;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IFacturaDA
    {
        Task<int> AgregarFactura(FacturaResponse factura);
        Task AgregarDetalle(Guid idFactura, FacturaItem item);
    }
}
