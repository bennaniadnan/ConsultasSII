CREATE TABLE [dbo].[Operaciones_Periodo] (
    [Ejercicio]       INT         NOT NULL,
    [Periodo]         VARCHAR (2) NOT NULL,
    [IdLibroRegistro] VARCHAR (2) NOT NULL,
    [Pendientes]      INT         DEFAULT 0 NULL,
    [Aceptados]       INT         DEFAULT 0 NULL,
    [ConErrores]      INT         DEFAULT 0 NULL,
    [Rechazados]      INT         DEFAULT 0 NULL,
    [FueraPlazo] INT NULL DEFAULT 0, 
    [NoFueraPlazo] INT NULL DEFAULT 0, 
    [NonIdentificado] INT NULL DEFAULT 0, 
    CONSTRAINT [PK_Operaciones_Periodo] PRIMARY KEY CLUSTERED ([Ejercicio] ASC, [Periodo] ASC, [IdLibroRegistro] ASC)
);

