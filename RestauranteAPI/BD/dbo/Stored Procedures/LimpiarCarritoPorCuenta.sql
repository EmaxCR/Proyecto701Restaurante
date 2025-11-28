CREATE PROCEDURE [dbo].[LimpiarCarritoPorCuenta]
    @IdCuenta UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Carrito WHERE IdCuenta = @IdCuenta;
END;