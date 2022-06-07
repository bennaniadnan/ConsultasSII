CREATE TABLE [dbo].[TipoLibro] (
    [Id]          VARCHAR (2)  NOT NULL,
    [Descripcion] VARCHAR (50) NULL,
    CONSTRAINT [PK_TipoLibro] PRIMARY KEY CLUSTERED ([Id] ASC)
);

