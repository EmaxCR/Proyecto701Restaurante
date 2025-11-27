using Abstracciones.Modelos.Servicios.Financia;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IFinanciaServicio
    {
        Task<FinanciaModelo> Obtener();

        string ObtenerFechaActual();
    }
}
