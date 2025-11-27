-- =============================================
-- Author:		Author,,Name
-- Create date: Create Date,,
-- Description:	Description,,
-- =============================================
CREATE PROCEDURE ObtenerSubCategoria
	-- Add the parameters for the stored procedure here
	 
	 @Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT        SubCategorias.Nombre AS SubCategoria, Categorias.Nombre AS Categoria, SubCategorias.Id
FROM            Categorias INNER JOIN
                         SubCategorias ON Categorias.Id = SubCategorias.IdCategoria
WHERE        (SubCategorias.Id = @Id)
END