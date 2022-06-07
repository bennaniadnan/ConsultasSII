CREATE TABLE [dbo].[FacturasAgrupadas] (
    [Id]                           INT          IDENTITY (1, 1) NOT NULL,
    [IdRegistroInformacion]        INT          NULL,
    [NumSerieFacturaEmisor]        VARCHAR (60) NULL,
    [FechaExpedicionFacturaEmisor] DATE         NULL,
    CONSTRAINT [PK__Facturas__3214EC07534D60F1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FacturasAgrupadas_RegistroInformacion] FOREIGN KEY ([IdRegistroInformacion]) REFERENCES [dbo].[RegistroInformacion] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_IdRegistroInformacion]
    ON [dbo].[FacturasAgrupadas]([IdRegistroInformacion] ASC);

