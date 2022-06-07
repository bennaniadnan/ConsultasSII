CREATE TABLE [dbo].[TipoFactura] (
    [id]          VARCHAR (2)   NOT NULL,
    [Descripcion] VARCHAR (200) NULL,
    [Orden]       INT           NULL,
    [IdAgencia]   VARCHAR (10)  NULL,
    CONSTRAINT [PK_TipoProyecto] PRIMARY KEY CLUSTERED ([id] ASC)
);

