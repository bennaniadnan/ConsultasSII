CREATE TABLE [dbo].[Pagos] (
    [Id]                    INT             IDENTITY (1, 1) NOT NULL,
    [IdRegistroInformacion] INT             NOT NULL,
    [Fecha]                 DATE            NOT NULL,
    [Importe]               DECIMAL (15, 2) CONSTRAINT [DF_Pagos_Importe] DEFAULT ((0)) NOT NULL,
    [IdMedio]               VARCHAR (2)     NOT NULL,
    [Cuenta_O_Medio]        VARCHAR (34)    NULL,
    [Nuevo]                 BIT             DEFAULT ((0)) NOT NULL,
    [IdEstadoCobroPago]     INT             NULL,
    CONSTRAINT [PK__Pagos__3214EC072A4B4B5E] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pagos_EstadoCobroPago] FOREIGN KEY ([IdEstadoCobroPago]) REFERENCES [dbo].[EstadoCobroPago] ([Id]),
    CONSTRAINT [FK_Pagos_RegistroInformacion] FOREIGN KEY ([IdRegistroInformacion]) REFERENCES [dbo].[RegistroInformacion] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_IdRegistroInformacion]
    ON [dbo].[Pagos]([IdRegistroInformacion] ASC);

