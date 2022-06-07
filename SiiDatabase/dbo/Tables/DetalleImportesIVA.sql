CREATE TABLE [dbo].[DetalleImportesIVA] (
    [Id]                        INT             IDENTITY (1, 1) NOT NULL,
    [IdRegistro]                INT             NULL,
    [TipoImpositivo]            DECIMAL (15, 2) CONSTRAINT [DF_DetalleImportesIVA_TipoImpositivo] DEFAULT ((0)) NOT NULL,
    [BaseImponible]             DECIMAL (15, 2) CONSTRAINT [DF_DetalleImportesIVA_BaseImponible] DEFAULT ((0)) NOT NULL,
    [CuotaRepercutida]          DECIMAL (15, 2) CONSTRAINT [DF_DetalleImportesIVA_CuotaRepercutida] DEFAULT ((0)) NULL,
    [TipoRecargoEquivalencia]   DECIMAL (15, 2) CONSTRAINT [DF_DetalleImportesIVA_TipoRecargoEquivalencia] DEFAULT ((0)) NULL,
    [CuotaRecargoEquivalencia]  DECIMAL (15, 2) CONSTRAINT [DF_DetalleImportesIVA_CuotaRecargoEquivalencia] DEFAULT ((0)) NULL,
    [ImporteCompensacionREAGYP] DECIMAL (15, 2) CONSTRAINT [DF_DetalleImportesIVA_ImporteCompensacionREAGYP] DEFAULT ((0)) NULL,
    [PorcentCompensacionREAGYP] DECIMAL (15, 2) CONSTRAINT [DF_DetalleImportesIVA_PorcentCompensacionREAGYP] DEFAULT ((0)) NULL,
    [IdTipoDetalleIVA]          INT             NULL,
    [CuotaSoportada]            DECIMAL (15, 2) CONSTRAINT [DF_DetalleImportesIVA_CuotaSoportada] DEFAULT ((0)) NULL,
    [CargaImpositivaImplicita]  DECIMAL (15, 2) DEFAULT ((0)) NULL,
    [CuotaRecargoMinorista]     DECIMAL (15, 2) DEFAULT ((0)) NULL,
    [BienInversion] VARCHAR NULL, 
    CONSTRAINT [PK__DetalleI__3214EC0732E0915F] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__DetalleIm__IdTip__7073AF84] FOREIGN KEY ([IdTipoDetalleIVA]) REFERENCES [dbo].[TipoDetalleIVA] ([Id]),
    CONSTRAINT [FK_DetalleImportesIVA_RegistroInformacion] FOREIGN KEY ([IdRegistro]) REFERENCES [dbo].[RegistroInformacion] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_IdRegistro]
    ON [dbo].[DetalleImportesIVA]([IdRegistro] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IdTipoDetalleIVA]
    ON [dbo].[DetalleImportesIVA]([IdTipoDetalleIVA] ASC);

