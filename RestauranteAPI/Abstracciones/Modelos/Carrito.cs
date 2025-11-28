using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    // batos base que llegan al carrito
    public class Carrito
    {
        [Required(ErrorMessage = "El Id de la cuenta es requerido")]
        public Guid IdCuenta { get; set; }

        [Required(ErrorMessage = "El IdProducto es requerido")]
        public Guid IdProducto { get; set; }

        [Required(ErrorMessage = "La Cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser al menos 1")]
        public int Cantidad { get; set; }
    }

    // recibe POST/PUT
    public class CarritoRequest : Carrito
    {
    }

    // devuelve al GET
    public class CarritoResponse : Carrito
    {
        public Guid Id { get; set; }

        
        public string NombreProducto { get; set; } = string.Empty;
        public string DescripcionProducto { get; set; } = string.Empty;
        public decimal PrecioProducto { get; set; }

        // calculado 
        public decimal TotalLinea => Cantidad * PrecioProducto;
    }
}
