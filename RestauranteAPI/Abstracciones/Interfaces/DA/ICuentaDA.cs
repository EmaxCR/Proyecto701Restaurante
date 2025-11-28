using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface ICuentaDA
    {
        Task<IEnumerable<CuentaResponse>> Obtener();
        Task<CuentaResponse> Obtener(Guid Id);
        Task<Guid> Abrir(CuentaRequest cuenta);
        Task<Guid> Cerrar(Guid Id);
    }
}
