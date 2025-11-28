CREATE TABLE [dbo].[Cuenta] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [NumeroCuenta]  INT              IDENTITY (1, 1) NOT NULL,
    [NombreCliente] VARCHAR (200)    NULL,
    [NumeroMesa]    INT              NULL,
    [FechaApertura] DATETIME         NOT NULL,
    [Estado]        VARCHAR (20)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

