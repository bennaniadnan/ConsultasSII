CREATE TABLE [dbo].[Periodo] (
    [Id]               VARCHAR (2)  NOT NULL,
    [Texte]            VARCHAR (20) NULL,
    [TipoPresentacion] CHAR (1)     DEFAULT ('M') NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

