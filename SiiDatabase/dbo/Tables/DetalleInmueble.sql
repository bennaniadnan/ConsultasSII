CREATE TABLE [dbo].[DetalleInmueble] (
    [Id]                    INT          IDENTITY (1, 1) NOT NULL,
    [IdRegistroInformacion] INT          NOT NULL,
    [SituacionInmueble]     INT          NULL,
    [ReferenciaCatastral]   VARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

