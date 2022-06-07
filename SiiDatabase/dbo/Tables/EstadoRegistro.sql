CREATE TABLE [dbo].[EstadoRegistro] (
    [id]          INT          NOT NULL,
    [Descripcion] VARCHAR (50) NULL,
    [Orden]       INT          NULL,
    CONSTRAINT [PK_EstadoRegistro] PRIMARY KEY CLUSTERED ([id] ASC)
);

