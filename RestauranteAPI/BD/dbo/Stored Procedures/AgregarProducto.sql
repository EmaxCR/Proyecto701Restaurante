
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarProducto]
	-- Add the parameters for the stored procedure here
@Id AS uniqueidentifier
           ,@IdSubCategoria AS uniqueidentifier
           ,@Nombre AS Varchar(Max)
           ,@Descripcion AS Varchar(Max)
           ,@Precio AS decimal(18,2)
           ,@Stock AS int
           ,@CodigoBarras AS Varchar(Max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    BEGIN TRANSACTION
INSERT INTO [dbo].[Producto]
           ([Id]
           ,[IdSubCategoria]
           ,[Nombre]
           ,[Descripcion]
           ,[Precio]
           ,[Stock]
           ,[CodigoBarras])
     VALUES
           (@Id
           ,@IdSubCategoria 
           ,@Nombre 
           ,@Descripcion
           ,@Precio
           ,@Stock
           ,@CodigoBarras)

           SELECT @Id
           COMMIT TRANSACTION
           END