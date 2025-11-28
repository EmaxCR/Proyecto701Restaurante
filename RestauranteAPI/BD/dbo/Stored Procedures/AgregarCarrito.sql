CREATE   PROCEDURE [dbo].[AgregarCarrito]
(
    @Id         UNIQUEIDENTIFIER,
    @IdCuenta   UNIQUEIDENTIFIER,
    @IdProducto UNIQUEIDENTIFIER,
    @Cantidad   INT
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Carrito (Id, IdCuenta, IdProducto, Cantidad, FechaCreacion)
    VALUES (@Id, @IdCuenta, @IdProducto, @Cantidad, GETDATE());

    SELECT @Id;
END;