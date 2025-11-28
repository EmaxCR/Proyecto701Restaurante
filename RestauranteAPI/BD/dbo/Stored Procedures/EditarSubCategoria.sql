CREATE PROCEDURE EditarSubCategoria
	-- Add the parameters for the stored procedure here
	  @Id AS uniqueidentifier
 ,@IdCategoria AS uniqueidentifier
 ,@Nombre AS varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION
	UPDATE [dbo].[SubCategorias]
   SET [IdCategoria] = @IdCategoria
      ,[Nombre] = @Nombre
 WHERE Id=@Id

 SELECT @Id
 COMMIT TRANSACTION
END