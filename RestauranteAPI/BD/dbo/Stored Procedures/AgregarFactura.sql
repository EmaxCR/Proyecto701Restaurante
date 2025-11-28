CREATE PROCEDURE [dbo].[AgregarFactura]
    @Id UNIQUEIDENTIFIER,
    @IdCuenta UNIQUEIDENTIFIER,
    @NombreCliente VARCHAR(200),
    @NumeroMesa INT,
    @Subtotal DECIMAL(18,2),
    @Impuesto DECIMAL(18,2),
    @Servicio DECIMAL(18,2),
    @TotalFinal DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Factura (
        Id, IdCuenta, Fecha,
        NombreCliente, NumeroMesa,
        Subtotal, Impuesto, Servicio, TotalFinal
    )
    VALUES (
        @Id, @IdCuenta, GETDATE(),
        @NombreCliente, @NumeroMesa,
        @Subtotal, @Impuesto, @Servicio, @TotalFinal
    );

    -- Devolvemos el número de factura (IDENTITY)
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NumeroFactura;
END;