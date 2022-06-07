CREATE TABLE [dbo].[Parameters] (
    [IdCliente]                 INT      NOT NULL,
    [FacturasAgrupadas]         BIT      DEFAULT ((0)) NOT NULL,
    [FacturasRectificadas]      BIT      DEFAULT ((0)) NOT NULL,
    [CobrosRECC]                BIT      DEFAULT ((0)) NOT NULL,
    [PagosRECC]                 BIT      DEFAULT ((0)) NOT NULL,
    [MultiRegistrosCatastrales] BIT      DEFAULT ((0)) NOT NULL,
    [TipoPresentacion]          CHAR (1) DEFAULT ('M') NOT NULL,
    [DatosComplementarios]      BIT      DEFAULT ((0)) NOT NULL,
    [Macrodato]                 BIT      DEFAULT ((0)) NULL,
    [ForPuenteConector]         BIT      DEFAULT ((0)) NOT NULL,
    [Validacion2021] BIT NULL DEFAULT ((0)), 
    PRIMARY KEY CLUSTERED ([IdCliente] ASC),
    CONSTRAINT [FK_Parameters_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id])
);

