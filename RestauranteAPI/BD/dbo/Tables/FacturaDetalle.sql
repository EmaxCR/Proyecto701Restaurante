CREATE TABLE [dbo].[FacturaDetalle] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [IdFactura]      UNIQUEIDENTIFIER NOT NULL,
    [NombreProducto] VARCHAR (200)    NOT NULL,
    [Cantidad]       INT              NOT NULL,
    [PrecioUnitario] DECIMAL (18, 2)  NOT NULL,
    [TotalLinea]     DECIMAL (18, 2)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

