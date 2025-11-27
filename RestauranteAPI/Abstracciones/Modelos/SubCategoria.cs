namespace Abstracciones.Modelos
{
    public class SubCategoria
    {
        public string Nombre { get; set; }
    }

    public class SubCategoriaRequest : SubCategoria
    {
        public Guid IdCategoria { get; set; }
    }

    public class SubCategoriaResponse : SubCategoria
    {
        public Guid Id { get; set; }
        public string Categoria { get; set; }
    }

}
