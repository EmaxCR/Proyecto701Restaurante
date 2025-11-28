CREATE PROCEDURE ObtenerSubCategorias
	-- Add the parameters for the stored procedure here
	 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        SubCategorias.Nombre AS Nombre, Categorias.Nombre AS Categoria, SubCategorias.Id
FROM            Categorias INNER JOIN
                         SubCategorias ON Categorias.Id = SubCategorias.IdCategoria
END