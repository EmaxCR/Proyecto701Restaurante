CREATE TABLE [dbo].[Carrito] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [IdProducto]    UNIQUEIDENTIFIER NOT NULL,
    [Cantidad]      INT              NOT NULL,
    [FechaCreacion] DATETIME         CONSTRAINT [DF_Carrito_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [NombreUsuario] VARCHAR (200)    NULL,
    [Cedula]        VARCHAR (20)     DEFAULT ('0000000000') NULL,
    [IdCuenta]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Carrito_Cuenta] FOREIGN KEY ([IdCuenta]) REFERENCES [dbo].[Cuenta] ([Id]),
    CONSTRAINT [FK_Carrito_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([Id])
);

