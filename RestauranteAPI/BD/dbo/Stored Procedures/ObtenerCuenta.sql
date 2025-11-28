CREATE PROCEDURE [dbo].[ObtenerCuenta]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        NumeroCuenta,
        NombreCliente,
        NumeroMesa,
        FechaApertura,
        Estado
    FROM Cuenta
    WHERE Id = @Id;
END