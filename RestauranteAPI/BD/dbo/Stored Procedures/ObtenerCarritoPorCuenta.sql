CREATE PROCEDURE [dbo].[ObtenerCarritoPorCuenta]
    @IdCuenta UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.Id,
        c.Cedula,
        c.IdProducto,
        c.Cantidad,
        c.FechaCreacion,
        c.NombreUsuario,
        c.IdCuenta,
        p.Nombre       AS NombreProducto,
        p.Descripcion  AS DescripcionProducto,
        p.Precio       AS PrecioProducto,
        p.CodigoBarras AS CodigoBarras,
        p.Stock        AS StockProducto
    FROM Carrito c
    INNER JOIN Producto p ON c.IdProducto = p.Id
    WHERE c.IdCuenta = @IdCuenta;
END