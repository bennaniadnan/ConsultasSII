CREATE TABLE [dbo].[TipoOperacion] (
    [Id]             VARCHAR (2)   NOT NULL,
    [Denominacion]   VARCHAR (100) NULL,
    [EstructuraXML]  VARCHAR (100) NULL,
    [ClaseOperacion] INT           NULL,
    CONSTRAINT [PK__TipoOper__3214EC070F975522] PRIMARY KEY CLUSTERED ([Id] ASC)
);

