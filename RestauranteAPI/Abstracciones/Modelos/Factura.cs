using System;
using System.Collections.Generic;

namespace Abstracciones.Modelos
{
    public class FacturaItem
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal TotalLinea { get; set; }

    }

    public class FacturaResponse
    {
        public Guid Id { get; set; }
        public int NumeroFactura { get; set; }

        public Guid IdCuenta { get; set; }
        public string NombreCliente { get; set; }
        public int NumeroMesa { get; set; }
        public DateTime Fecha { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Servicio { get; set; }
        public decimal TotalFinal { get; set; }

        public List<FacturaItem> Items { get; set; } = new();
    }
}
