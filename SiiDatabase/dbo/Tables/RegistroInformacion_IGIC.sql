CREATE TABLE [dbo].[RegistroInformacion_IGIC] (
    [IdRegistroInformacion] INT           NOT NULL,
    [PagoAnticipado]        CHAR (1)      NULL,
    [IdTipoBienOperacion]   VARCHAR (2)   NULL,
    [IdTipoDocumentoArt25]  VARCHAR (2)   NULL,
    [NumeroProtocolo]       VARCHAR (6)   NULL,
    [NombreNotario]         VARCHAR (120) NULL,
    PRIMARY KEY CLUSTERED ([IdRegistroInformacion] ASC),
    FOREIGN KEY ([IdRegistroInformacion]) REFERENCES [dbo].[RegistroInformacion] ([Id]),
    FOREIGN KEY ([IdTipoBienOperacion]) REFERENCES [dbo].[TipoBienOperacion] ([Id]),
    FOREIGN KEY ([IdTipoDocumentoArt25]) REFERENCES [dbo].[TipoDocumentoArt25] ([Id])
);

