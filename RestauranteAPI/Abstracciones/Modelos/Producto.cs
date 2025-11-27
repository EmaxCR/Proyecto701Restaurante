using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class Producto
    {
        [Required(ErrorMessage ="El Nombre es requerido")]
        [StringLength(100, ErrorMessage = "El Nombre no debe ser de más de 100 carácteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Descripcion es requerida")]
        [StringLength(1200, ErrorMessage = "La Descripcion no debe ser de más de 100 carácteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Precio es requerido")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "El Stock es requerido")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "El Codigo de Barras es requerido")]
        [RegularExpression(@"^[A-Z]-\d{4}-[A-Z]$",ErrorMessage = "El Codigo de Barras debe ser X-####-X")]
        public string CodigoBarras { get; set; }
    }

    public class ProductoRequest : Producto
    {
        public Guid IdSubCategoria { get; set; }
    }

    public class ProductoResponse : Producto
    {
        public Guid Id { get; set; }
        public string SubCategoria { get; set; }
        public string Categoria { get; set; }

      
    }

    public class ProductoDetalle : ProductoResponse 
    {
        public decimal PrecioDolar { get; set; }

    }
}