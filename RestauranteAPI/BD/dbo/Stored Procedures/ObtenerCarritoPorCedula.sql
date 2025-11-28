CREATE PROCEDURE [dbo].[ObtenerCarritoPorCedula]
    @Cedula VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.Id,
        c.IdProducto,
        c.Cantidad,
        c.FechaCreacion,
        c.NombreUsuario,
        c.Cedula,
        p.Nombre       AS NombreProducto,
        p.Descripcion  AS DescripcionProducto,
        p.Precio       AS PrecioProducto,
        p.CodigoBarras AS CodigoBarras,
        p.Stock        AS StockProducto
    FROM Carrito c
    INNER JOIN Producto p ON c.IdProducto = p.Id
    WHERE 
        c.Cedula = @Cedula
        AND CAST(c.FechaCreacion AS date) = CAST(GETDATE() AS date);
END;