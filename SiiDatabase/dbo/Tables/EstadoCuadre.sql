CREATE TABLE [dbo].[EstadoCuadre] (
    [Id]          INT           NOT NULL,
    [Name]        VARCHAR (30)  NOT NULL,
    [DisplayName] VARCHAR (30)  NOT NULL,
    [Descripcion] VARCHAR (256) NULL,
    CONSTRAINT [PK_EstadoCuadre] PRIMARY KEY CLUSTERED ([Id] ASC)
);

