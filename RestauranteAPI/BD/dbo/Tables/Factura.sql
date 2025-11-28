CREATE TABLE [dbo].[Factura] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [NumeroFactura] INT              IDENTITY (1, 1) NOT NULL,
    [IdCuenta]      UNIQUEIDENTIFIER NOT NULL,
    [Fecha]         DATETIME         NOT NULL,
    [NombreCliente] VARCHAR (200)    NULL,
    [NumeroMesa]    INT              NULL,
    [Subtotal]      DECIMAL (18, 2)  NOT NULL,
    [Impuesto]      DECIMAL (18, 2)  NOT NULL,
    [Servicio]      DECIMAL (18, 2)  NOT NULL,
    [TotalFinal]    DECIMAL (18, 2)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

