CREATE TABLE [dbo].[Libros]
(
	[Id] INT PRIMARY KEY,
    [EstadoRegistro] VARCHAR (2)     NULL,
    [NumeroFactura] VARCHAR (60)     NULL,
    [FechaFactura] VARCHAR (10)     NULL,
    [FechaRegContable] VARCHAR (10)     NULL,
    [IdFiscal] VARCHAR (20)     NULL,
    [IsNifContraparte] BIT    NULL,
    [NombreContraparte]                  VARCHAR (120)   NULL,
    [CodigoPaisContraparte]              VARCHAR (2)     NULL,
    [IDTypeContraparte]                  VARCHAR (2)     NULL,
    [TipoFactura]                        VARCHAR (2)     NULL,
    [ClaveRegimenEspecial] VARCHAR (2)     NULL,
    [ImporteTotal]                       DECIMAL (15, 2) DEFAULT ((0)) NULL,
    [TipoNoSujeto] VARCHAR (2)     NULL,
    [BaseNoSujeta] DECIMAL (15, 2)     NULL,
    [TipoDesglose] VARCHAR (2)     NULL,
    [BaseExenta] DECIMAL (15, 2) NULL,
    [CausaExencion]                      VARCHAR (2)     NULL,
    [TipoDeSujecion]                      VARCHAR (3)     NULL,
    [CuotaDeducible]                     DECIMAL (15, 2) DEFAULT ((0)) NULL,
    [Ejercicio]                          INT             NULL,
    [Periodo]                            VARCHAR (2)     NULL,
    [IdEstadoCuadre]                     INT             NULL,
    [RefExterna]            VARCHAR (60)  NULL,
    [IdEstadoRegistro] INT NULL, 
    [IdLibroRegistro] VARCHAR (2) NULL, 
    [IDContraparte]  VARCHAR (20)  NULL,
    [NifContraparte] VARCHAR (20) NULL,    
    [NumSerieFacturaEmisor] VARCHAR (60) NULL,
    [FechaOperacion] DATE NULL,
    [Baja] BIT NULL,
    [IdEstadoLectura] INT NULL, 
    [CountDetalleIVA] DECIMAL(15, 2) NULL,
    [BaseImponible] DECIMAL(15, 2) NULL,
    [CuotaIVA] DECIMAL(15, 2) NULL,
    [TipoRE] DECIMAL(15, 2) NULL,
    [CuotaRE] DECIMAL(15, 2) NULL
)
GO

CREATE NONCLUSTERED INDEX [IX_LIBROS_EJERCICIO]
    ON [dbo].[Libros]([IdLibroRegistro] DESC,[Ejercicio] DESC,[Periodo] DESC);

GO
	
CREATE NONCLUSTERED INDEX [IX_LIBROS_OTROS_CAMPOS]
    ON [dbo].[Libros]([IdLibroRegistro] DESC,[Ejercicio] DESC,[Periodo] DESC, [IdEstadoRegistro] DESC, [IdEstadoLectura] DESC, [IDContraparte] DESC, [NifContraparte] DESC, [NumSerieFacturaEmisor] DESC, [FechaFactura] DESC, [Baja] DESC);

GO


--GO

--CREATE NONCLUSTERED INDEX [IX_LIBROS]
--    ON [dbo].[Libros]([IdEstadoRegistro] ASC, [IdLibroRegistro] ASC, [Ejercicio] ASC, [Periodo] ASC, [IDContraparte] ASC, [NifContraparte] ASC, [Id] ASC, [NumSerieFacturaEmisor] ASC, [FechaFactura] ASC, [FechaRegContable] ASC, [FechaOperacion] ASC, [Baja] ASC, [IdEstadoLectura] ASC);

--GO

--CREATE NONCLUSTERED INDEX [IX_LIBROS_EJERCICIO]
--    ON [dbo].[Libros]([IdLibroRegistro],[Ejercicio],[Periodo]);

--GO
	
--CREATE NONCLUSTERED INDEX [IX_LIBROS_OTROS_CAMPOS]
--    ON [dbo].[Libros]([IdEstadoRegistro],[IDContraparte],[NifContraparte],
--    [Id], [NumSerieFacturaEmisor], [FechaFactura],[FechaRegContable],[FechaOperacion],[Baja],[IdEstadoLectura]);
