CREATE TABLE [dbo].[DatosDescuadreContraparte] (
    [IdRegistroInformacion]       INT             NOT NULL,
    [SumBaseImponibleISP]         DECIMAL (15, 2) NULL,
    [SumBaseImponible]            DECIMAL (15, 2) NULL,
    [SumCuota]                    DECIMAL (15, 2) NULL,
    [SumCuotaRecargoEquivalencia] DECIMAL (15, 2) NULL,
    [ImporteTotal]                DECIMAL (15, 2) NULL,
    CONSTRAINT [PK_DatosDescuadreContraparte] PRIMARY KEY CLUSTERED ([IdRegistroInformacion] ASC),
    CONSTRAINT [FK_DatosDescuadreContraparte_RegistroInformacion] FOREIGN KEY ([IdRegistroInformacion]) REFERENCES [dbo].[RegistroInformacion] ([Id])
);

