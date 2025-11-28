using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class Cuenta
    {
        [StringLength(200, ErrorMessage = "El nombre no debe ser de más de 200 caracteres")]
        public string? NombreCliente { get; set; }

        public int? NumeroMesa { get; set; }

        public DateTime FechaApertura { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [StringLength(20)]
        public string Estado { get; set; } = "Abierta";
    }

    public class CuentaRequest : Cuenta
    {
       
    }

    public class CuentaResponse : Cuenta
    {
        public Guid Id { get; set; }
        public int NumeroCuenta { get; set; }
    }
}
