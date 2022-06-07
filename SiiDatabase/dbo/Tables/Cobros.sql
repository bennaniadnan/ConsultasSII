CREATE TABLE [dbo].[Cobros] (
    [Id]                    INT             IDENTITY (1, 1) NOT NULL,
    [IdRegistroInformacion] INT             NOT NULL,
    [Fecha]                 DATE            NOT NULL,
    [Importe]               DECIMAL (15, 2) CONSTRAINT [DF_Cobros_Importe] DEFAULT ((0)) NOT NULL,
    [IdMedio]               VARCHAR (2)     NOT NULL,
    [Cuenta_O_Medio]        VARCHAR (34)    NULL,
    [Nuevo]                 BIT             DEFAULT ((0)) NOT NULL,
    [IdEstadoCobroPago]     INT             NULL,
    CONSTRAINT [PK__Cobros__3214EC0736B12243] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cobros_EstadoCobroPago] FOREIGN KEY ([IdEstadoCobroPago]) REFERENCES [dbo].[EstadoCobroPago] ([Id]),
    CONSTRAINT [FK_Cobros_RegistroInformacion] FOREIGN KEY ([IdRegistroInformacion]) REFERENCES [dbo].[RegistroInformacion] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_IdRegistroInformacion]
    ON [dbo].[Cobros]([IdRegistroInformacion] ASC);

