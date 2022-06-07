CREATE TABLE [dbo].[RegistrosOperacion] (
    [Id]                       INT           IDENTITY (1, 1) NOT NULL,
    [IdOperacion]              INT           NULL,
    [IdRegistroInformacion]    INT           NULL,
    [IdEstadoRegistro]         INT           CONSTRAINT [DF_RegistrosOperacion_IdEstadoRegistro] DEFAULT ((0)) NULL,
    [CodigoErrorRegistro]      INT           NULL,
    [DescripcionErrorRegistro] VARCHAR (500) NULL,
    CONSTRAINT [PK__Registro__3214EC0722AA2996] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Registros__IdOpe__24927208] FOREIGN KEY ([IdOperacion]) REFERENCES [dbo].[Operacion] ([Id]),
    CONSTRAINT [FK_RegistrosOperacion_EstadoRegistro] FOREIGN KEY ([IdEstadoRegistro]) REFERENCES [dbo].[EstadoRegistro] ([id]),
    CONSTRAINT [FK_RegistrosOperacion_RegistroInformacion] FOREIGN KEY ([IdRegistroInformacion]) REFERENCES [dbo].[RegistroInformacion] ([Id])
);






GO
CREATE NONCLUSTERED INDEX [IX_IdEstadoRegistro]
    ON [dbo].[RegistrosOperacion]([IdEstadoRegistro] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IdOperacion]
    ON [dbo].[RegistrosOperacion]([IdOperacion] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IdRegistroInformacion]
    ON [dbo].[RegistrosOperacion]([IdRegistroInformacion] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_REGISTROSINFORMACION_ID]
    ON [dbo].[RegistrosOperacion]([IdRegistroInformacion] ASC, [IdOperacion] ASC, [IdEstadoRegistro] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_RegistrosOperacion]
    ON [dbo].[RegistrosOperacion]([IdOperacion] ASC, [IdRegistroInformacion] ASC);


GO
