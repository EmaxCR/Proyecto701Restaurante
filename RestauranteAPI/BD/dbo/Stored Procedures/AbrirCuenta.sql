CREATE PROCEDURE [dbo].[AbrirCuenta]
    @Id            UNIQUEIDENTIFIER,
    @NombreCliente VARCHAR(200) = NULL,
    @NumeroMesa    INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    INSERT INTO Cuenta (Id, NombreCliente, NumeroMesa, FechaApertura, Estado)
    VALUES (@Id, @NombreCliente, @NumeroMesa, GETDATE(), 'Abierta');

    SELECT @Id;

    COMMIT TRANSACTION;
END