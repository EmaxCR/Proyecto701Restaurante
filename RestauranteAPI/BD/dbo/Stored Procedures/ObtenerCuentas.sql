CREATE PROCEDURE [dbo].[ObtenerCuentas]
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
    FROM Cuenta;
END