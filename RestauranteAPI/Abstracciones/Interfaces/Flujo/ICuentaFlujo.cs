using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface ICuentaFlujo
    {
        Task<IEnumerable<CuentaResponse>> Obtener();
        Task<CuentaResponse> Obtener(Guid Id);
        Task<Guid> Abrir(CuentaRequest cuenta);
        Task<FacturaResponse> Cerrar(Guid Id);
    }
}
