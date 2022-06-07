CREATE TABLE [dbo].[CausaExencion] (
    [CausaExencion] VARCHAR (2)   NOT NULL,
    [IdAgencia]     VARCHAR (10)  NULL,
    [Descripcion]   VARCHAR (256) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Id_IdAgencia]
    ON [dbo].[CausaExencion]([CausaExencion] ASC, [IdAgencia] ASC);

