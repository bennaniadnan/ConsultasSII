CREATE TABLE [dbo].[RegistroInformacion] (
    [Id]                                 INT             IDENTITY (1, 1) NOT NULL,
    [IdLibroRegistro]                    VARCHAR (2)     NULL,
    [NifDeclarante]                      VARCHAR (9)     NULL,
    [NifFacturaEmisor]                   VARCHAR (20)    NULL,
    [NumSerieFacturaEmisor]              VARCHAR (60)    NULL,
    [NumSerieFacturaEmisorResumenFin]    VARCHAR (60)    NULL,
    [FechaExpedicionFacturaEmisor]       DATE            NULL,
    [TipoFactura]                        VARCHAR (2)     NULL,
    [NombreRazon]                        VARCHAR (120)   NULL,
    [NIFRepresentante]                   VARCHAR (9)     NULL,
    [NifContraparte]                     VARCHAR (20)    NULL,
    [CodigoPaisContraparte]              VARCHAR (2)     NULL,
    [IDTypeContraparte]                  VARCHAR (2)     NULL,
    [IDContraparte]                      VARCHAR (20)    NULL,
    [CodigoPaisIdFactura]                VARCHAR (2)     NULL,
    [IDTypeIdFactura]                    VARCHAR (2)     NULL,
    [IDIdFactura]                        VARCHAR (20)    NULL,
    [BaseRectificada]                    DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_BaseRectificada] DEFAULT ((0)) NULL,
    [CuotaRectificada]                   DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_CuotaRectificada] DEFAULT ((0)) NULL,
    [CuotaRecargoRectificada]            DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_CuotaRecargoRectificada] DEFAULT ((0)) NULL,
    [TipoRectificativa]                  VARCHAR (2)     NULL,
    [FechaExpedicionFactura]             DATE            NULL,
    [FechaOperacion]                     DATE            NULL,
    [ImporteTotal]                       DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_ImporteTotal] DEFAULT ((0)) NULL,
    [ClaveRegimenEspecialOTrascendencia] VARCHAR (2)     NULL,
    [BaseImponibleACoste]                DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_BaseImponibleACoste] DEFAULT ((0)) NULL,
    [DescripcionOperacion]               VARCHAR (500)   NULL,
    [SituacionInmueble]                  INT             NULL,
    [ReferenciaCatastral]                VARCHAR (25)    NULL,
    [TipoNoSujeta]                       VARCHAR (2)     NULL,
    [ImporteTransmisionSujetoAIVA]       DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_ImporteTransmisionSujetoAIVA] DEFAULT ((0)) NULL,
    [EmitidaPorTerceros]                 VARCHAR (1)     NULL,
    [NumeroDUA]                          VARCHAR (40)    NULL,
    [FechaRegContableDUA]                DATE            NULL,
    [FechaRegContable]                   DATE            NULL,
    [CuotaDeducible]                     DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_CuotaDeducible] DEFAULT ((0)) NULL,
    [TipoOperacion]                      VARCHAR (1)     NULL,
    [ClaveDeclarado]                     VARCHAR (1)     NULL,
    [EstadoMiembro]                      VARCHAR (2)     NULL,
    [PlazoOperacion]                     INT             NULL,
    [DescripcionBienes]                  VARCHAR (120)   NULL,
    [DireccionOperador]                  VARCHAR (150)   NULL,
    [FacturasODocumentacion]             VARCHAR (150)   NULL,
    [ProrrataAnualDefinitiva]            VARCHAR (5)     NULL,
    [RegularizacionAnualDeduccion]       DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_RegularizacionAnualDeduccion] DEFAULT ((0)) NULL,
    [IdentificacionEntrega]              VARCHAR (40)    NULL,
    [RegularizacionDeduccionEfectuada]   DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_RegularizacionDeduccionEfectuada] DEFAULT ((0)) NULL,
    [Ejercicio]                          INT             NULL,
    [FechaInicioUtilizacion]             DATE            NULL,
    [IdentificacionBien]                 VARCHAR (40)    NULL,
    [Baja]                               BIT             NULL,
    [FechaBaja]                          DATETIME        NULL,
    [IdEstadoLectura]                    INT             CONSTRAINT [DF_RegistroInformacion_Modificada] DEFAULT ((0)) NULL,
    [Cupon]                              VARCHAR (1)     NULL,
    [VariosDestinatarios]                VARCHAR (1)     NULL,
    [NombreContraparte]                  VARCHAR (120)   NULL,
    [IdEstadoRegistro]                   INT             NULL,
    [CausaExencion]                      VARCHAR (2)     NULL,
    [BaseImponible]                      DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_BaseImponible] DEFAULT ((0)) NULL,
    [TipoNoExenta]                       VARCHAR (2)     NULL,
    [ImportePorArticulos7_14_Otros]      DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_ImportePorArticulos7_14_Otros] DEFAULT ((0)) NULL,
    [ImporteTAIReglasLocalizacion]       DECIMAL (15, 2) CONSTRAINT [DF_RegistroInformacion_ImporteTAIReglasLocalizacion] DEFAULT ((0)) NULL,
    [TipoDesglose]                       INT             NULL,
    [DesgloseTipoOperacion]              INT             NULL,
    [Periodo]                            VARCHAR (2)     NULL,
    [IdEstadoCuadre]                     INT             NULL,
    [FechaFinPlazo] DATE NULL, 
    [ADeducirEnPeriodoPosterior] VARCHAR NULL, 
    [EjercicioDeduccion] INT NULL, 
    [PeriodoDeduccion] VARCHAR(2) NULL, 
    CONSTRAINT [PK__Registro__3214EC072B3F6F97] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdEstadoLectura]) REFERENCES [dbo].[Estadolectura] ([id]),
    CONSTRAINT [FK_RegistroInformacion_EstadoCuadre] FOREIGN KEY ([IdEstadoCuadre]) REFERENCES [dbo].[EstadoCuadre] ([Id]),
    CONSTRAINT [FK_RegistroInformacion_EstadoLecturo] FOREIGN KEY ([IdEstadoLectura]) REFERENCES [dbo].[Estadolectura] ([id]),
    CONSTRAINT [FK_RegistroInformacion_LibroRegistro] FOREIGN KEY ([IdLibroRegistro]) REFERENCES [dbo].[LibroRegistro] ([Id]),
    CONSTRAINT [FK_RegistroInformacion_PaisResidencia] FOREIGN KEY ([IDTypeContraparte]) REFERENCES [dbo].[TipoDocumento] ([Id]),
    CONSTRAINT [FK_RegistroInformacion_PaisResidencia1] FOREIGN KEY ([IDTypeIdFactura]) REFERENCES [dbo].[TipoDocumento] ([Id]),
    CONSTRAINT [FK_RegistroInformacion_Periodo] FOREIGN KEY ([Periodo]) REFERENCES [dbo].[Periodo] ([Id]),
    CONSTRAINT [FK_RegistroInformacion_PeriodoDeduccion] FOREIGN KEY ([PeriodoDeduccion]) REFERENCES [dbo].[Periodo] ([Id]),
    CONSTRAINT [FK_RegistroInformacion_TipoFactura] FOREIGN KEY ([TipoFactura]) REFERENCES [dbo].[TipoFactura] ([id]),
    CONSTRAINT [AK_RegistroInformacion_Factura] UNIQUE ([NifFacturaEmisor], [NumSerieFacturaEmisor], [FechaExpedicionFacturaEmisor], [IDIdFactura])
);




GO
CREATE NONCLUSTERED INDEX [IX_IdEstadoLectura]
    ON [dbo].[RegistroInformacion]([IdEstadoLectura] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IdLibroRegistro]
    ON [dbo].[RegistroInformacion]([IdLibroRegistro] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IDTypeContraparte]
    ON [dbo].[RegistroInformacion]([IDTypeContraparte] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IDTypeIdFactura]
    ON [dbo].[RegistroInformacion]([IDTypeIdFactura] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_REGISTROINFORMACION_FILTERS]
    ON [dbo].[RegistroInformacion]([NifFacturaEmisor] ASC, [NifContraparte] ASC, [NumSerieFacturaEmisor] ASC, [NombreContraparte] ASC, [NombreRazon] ASC, [FechaExpedicionFacturaEmisor] ASC, [ImporteTotal] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_REGISTROINFORMACION_LIBROS]
    ON [dbo].[RegistroInformacion]([IdLibroRegistro] ASC, [IdEstadoRegistro] ASC, [Ejercicio] ASC, [Periodo] ASC, [Baja] ASC, [IdEstadoLectura] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_REGISTROINFORMACION_QUERY_APROCESSAR]
    ON [dbo].[RegistroInformacion]([Periodo] ASC)
    INCLUDE([Id], [IdLibroRegistro], [NifFacturaEmisor], [NumSerieFacturaEmisor], [FechaExpedicionFacturaEmisor], [NombreRazon], [NifContraparte], [ImporteTotal], [Ejercicio], [IdEstadoLectura], [NombreContraparte], [IdEstadoRegistro]);
GO

CREATE NONCLUSTERED INDEX [IX_TipoFactura]
    ON [dbo].[RegistroInformacion]([TipoFactura] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_REGISTROINFORMACION_QUERY_PENDIENTESCORRECCION]
    ON [dbo].[RegistroInformacion]([IdEstadoRegistro] ASC)
    INCLUDE([Id], [IdLibroRegistro], [IdEstadoLectura], [Periodo]);

GO
CREATE NONCLUSTERED INDEX [IX_REGISTROINFORMACION_QUERY_LIBRO]
    ON [dbo].[RegistroInformacion]([IdLibroRegistro] ASC, [IdEstadoLectura] ASC, [IdEstadoRegistro] ASC)
    INCLUDE([Id], [NumSerieFacturaEmisor], [FechaExpedicionFacturaEmisor], [NifContraparte], [IDContraparte], [FechaOperacion], [FechaRegContable], [Ejercicio], [Baja], [Periodo]);
