CREATE PROCEDURE [dbo].[AgregarFacturaDetalle]
    @Id UNIQUEIDENTIFIER,
    @IdFactura UNIQUEIDENTIFIER,
    @NombreProducto VARCHAR(200),
    @Cantidad INT,
    @PrecioUnitario DECIMAL(18,2),
    @TotalLinea DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO FacturaDetalle (
        Id, IdFactura,
        NombreProducto, Cantidad,
        PrecioUnitario, TotalLinea
    )
    VALUES (
        @Id, @IdFactura,
        @NombreProducto, @Cantidad,
        @PrecioUnitario, @TotalLinea
    );
END;