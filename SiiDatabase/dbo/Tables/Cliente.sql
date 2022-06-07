CREATE TABLE [dbo].[Cliente] (
    [Id]            INT           NOT NULL,
    [Nif]           VARCHAR (9)   NULL,
    [NombreCliente] VARCHAR (100) NULL,
    [Dirrection1]   VARCHAR (100) NULL,
    [Dirrection2]   VARCHAR (100) NULL,
    [CodigoPostal]  VARCHAR(50)           NULL,
    [Poblacion]     VARCHAR (100) NULL,
    [Telefono]      VARCHAR (20)  NULL,
    [EstadoCliente] INT           CONSTRAINT [DF__Cliente__EstadoC__47DBAE45] DEFAULT ((1)) NULL,
    CONSTRAINT [PK__Cliente__3214EC070519C6AF] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ__Cliente__NIF] UNIQUE NONCLUSTERED ([Nif] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cliente]
    ON [dbo].[Cliente]([Nif] ASC);

