CREATE TABLE [dbo].[ClaveRegimen] (
    [Id]              VARCHAR (2)   NOT NULL,
    [IdLibroRegistro] VARCHAR (2)   NULL,
    [IdAgencia]       VARCHAR (10)  NULL,
    [Descripcion]     VARCHAR (300) NULL,
    CONSTRAINT [FK_ClaveRegimen_LibroRegistro] FOREIGN KEY ([IdLibroRegistro]) REFERENCES [dbo].[LibroRegistro] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ClaveRegimen_Libro_Agencia]
    ON [dbo].[ClaveRegimen]([Id] ASC, [IdLibroRegistro] ASC, [IdAgencia] ASC);

