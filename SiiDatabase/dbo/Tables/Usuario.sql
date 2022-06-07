CREATE TABLE [dbo].[Usuario] (
    [Id]            VARCHAR (128) NOT NULL,
    [IdCliente]     INT           NULL,
    [Email]         VARCHAR (100) NULL,
    [Nombre]        VARCHAR (25)  NULL,
    [Apellidos]     VARCHAR (50)  NULL,
    [TelUsuario]    VARCHAR (20)  NULL,
    [TipoUsuario]   INT           NULL,
    [EstadoUsuario] INT           CONSTRAINT [DF__Usuario__EstadoU__48CFD27E] DEFAULT ((1)) NULL,
    [IdAutoNum]     INT           IDENTITY (1, 1) NOT NULL,
    [UserName]      VARCHAR (50)  NULL,
    [UserId]        VARCHAR (6)   NULL,
    CONSTRAINT [PK__Usuario__3214EC0721B6055D] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Usuario__IdClien__4CA06362] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id]),
    CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY ([TipoUsuario]) REFERENCES [dbo].[TipoUsuario] ([id]),
    CONSTRAINT [IX_Usuario_2] UNIQUE NONCLUSTERED ([UserId] ASC),
    CONSTRAINT [UQ__Usuario__Email] UNIQUE NONCLUSTERED ([Email] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_IdCliente]
    ON [dbo].[Usuario]([IdCliente] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TipoUsuario]
    ON [dbo].[Usuario]([TipoUsuario] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Usuario]
    ON [dbo].[Usuario]([IdCliente] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Usuario_1]
    ON [dbo].[Usuario]([Email] ASC);

