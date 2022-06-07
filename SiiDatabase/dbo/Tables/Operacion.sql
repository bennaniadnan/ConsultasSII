CREATE TABLE [dbo].[Operacion] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [IdTipoOperacion]        VARCHAR (2)   NULL,
    [IdUsuario]              VARCHAR (6)   NULL,
    [IdCliente]              INT           NULL,
    [IdEstadoOperacion]      INT           CONSTRAINT [DF__Operacion__IdEst__1FCDBCEB] DEFAULT ((0)) NULL,
    [IdResultadoOperacion]   INT           NULL,
    [Ejercicio]              INT           NULL,
    [Periodo]                VARCHAR (2)   NULL,
    [FechaEntrada]           DATE          NULL,
    [HoraEntrada]            TIME (0)      NULL,
    [FechaOperacion]         DATE          NULL,
    [IdLibroRegistro]        VARCHAR (2)   NULL,
    [HoraOperacion]          TIME (0)      NULL,
    [CSV]                    VARCHAR (30)  NULL,
    [XmlEnviada]             VARCHAR (100) NULL,
    [XmlRespuesta]           VARCHAR (100) NULL,
    [Pendientes]             INT           NULL,
    [Aceptados]              INT           NULL,
    [AceptadosCondicionados] INT           NULL,
    [Rechazados]             INT           NULL,
    CONSTRAINT [PK__Operacio__3214EC071B0907CE] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Operacion__IdCli__1ED998B2] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id]),
    CONSTRAINT [FK__Operacion__IdTip__1CF15040] FOREIGN KEY ([IdTipoOperacion]) REFERENCES [dbo].[TipoOperacion] ([Id]),
    CONSTRAINT [FK_Operacion_EstadoOperacion] FOREIGN KEY ([IdEstadoOperacion]) REFERENCES [dbo].[EstadoOperacion] ([Id]),
    CONSTRAINT [FK_Operacion_LibroRegistro] FOREIGN KEY ([IdLibroRegistro]) REFERENCES [dbo].[LibroRegistro] ([Id]),
    CONSTRAINT [FK_Operacion_Periodo] FOREIGN KEY ([Periodo]) REFERENCES [dbo].[Periodo] ([Id]),
    CONSTRAINT [FK_Operacion_ResultadoOperacion] FOREIGN KEY ([IdResultadoOperacion]) REFERENCES [dbo].[ResultadoOperacion] ([Id]),
    CONSTRAINT [FK_Operacion_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([UserId])
);

GO
CREATE NONCLUSTERED INDEX [IX_IdCliente]
    ON [dbo].[Operacion]([IdCliente] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_IdEstadoOperacion]
    ON [dbo].[Operacion]([IdEstadoOperacion] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_IdLibroRegistro]
    ON [dbo].[Operacion]([IdLibroRegistro] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_IdResultadoOperacion]
    ON [dbo].[Operacion]([IdResultadoOperacion] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_IdTipoOperacion]
    ON [dbo].[Operacion]([IdTipoOperacion] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_OPERATION_FILTERS]
    ON [dbo].[Operacion]([Periodo] ASC, [Ejercicio] ASC, [IdLibroRegistro] ASC, [IdEstadoOperacion] ASC, [IdResultadoOperacion] ASC, [FechaOperacion] ASC, [HoraOperacion] ASC, [FechaEntrada] ASC, [CSV] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_OPERATION_USER]
    ON [dbo].[Operacion]([IdUsuario] ASC);
