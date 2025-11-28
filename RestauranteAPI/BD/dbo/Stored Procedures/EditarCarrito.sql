CREATE   PROCEDURE [dbo].[EditarCarrito]
(
    @Id         UNIQUEIDENTIFIER,
    @IdCuenta   UNIQUEIDENTIFIER,
    @IdProducto UNIQUEIDENTIFIER,
    @Cantidad   INT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Carrito
    SET IdCuenta     = @IdCuenta,
        IdProducto   = @IdProducto,
        Cantidad     = @Cantidad
    WHERE Id = @Id;

    SELECT @Id;
END;