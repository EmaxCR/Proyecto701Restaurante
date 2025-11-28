CREATE   PROCEDURE [dbo].[ObtenerCarrito]
(
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.Id,
        c.IdCuenta,
        c.IdProducto,
        c.Cantidad,
        p.Nombre      AS NombreProducto,
        p.Descripcion AS DescripcionProducto,
        p.Precio      AS PrecioProducto
    FROM Carrito c
    INNER JOIN Producto p ON c.IdProducto = p.Id
    WHERE c.Id = @Id;
END;