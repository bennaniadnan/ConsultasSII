CREATE TABLE [dbo].[DatosComplementarios] (
    [IdRegistroInformacion] INT           NOT NULL,
    [ClaveRegimen1]         VARCHAR (2)   NULL,
    [ClaveRegimen2]         VARCHAR (2)   NULL,
    [Autorizacion]          VARCHAR (15)  NULL,
    [RefExterna]            VARCHAR (60)  NULL,
    [SimplificadaArt]       CHAR (1)      CONSTRAINT [DF__DatosComp__Simpl__40F9A68C] DEFAULT ('N') NULL,
    [NombreSucedida]        VARCHAR (160) NULL,
    [NifSucedida]           VARCHAR (9)   NULL,
    [RegPrevio]             CHAR (1)      CONSTRAINT [DF__DatosComp__RegPr__41EDCAC5] DEFAULT ('N') NULL,
    [Macrodato]             CHAR (1)      CONSTRAINT [DF__DatosComp__Macro__42E1EEFE] DEFAULT ('N') NULL,
    [FacturaEnergia]        CHAR (1)      CONSTRAINT [DF__DatosComp__Factu__43D61337] DEFAULT ('N') NULL,
    [SinDestinatario]       CHAR (1)      CONSTRAINT [DF__DatosComp__SinDe__44CA3770] DEFAULT ('N') NULL,
    CONSTRAINT [PK__DatosCom__443001AD281975FF] PRIMARY KEY CLUSTERED ([IdRegistroInformacion] ASC),
    CONSTRAINT [CK_DatosComplementarios_FacturaEnergia] CHECK ([FacturaEnergia]='N' OR [FacturaEnergia]='S'),
    CONSTRAINT [CK_DatosComplementarios_Macrodato] CHECK ([Macrodato]='N' OR [Macrodato]='S'),
    CONSTRAINT [CK_DatosComplementarios_RegPrevio] CHECK ([RegPrevio]='N' OR [RegPrevio]='S'),
    CONSTRAINT [CK_DatosComplementarios_SimplificadaArt] CHECK ([SimplificadaArt]='N' OR [SimplificadaArt]='S'),
    CONSTRAINT [CK_DatosComplementarios_SinDestinatario] CHECK ([SinDestinatario]='N' OR [SinDestinatario]='S'),
    CONSTRAINT [FK_DatosComplementarios_RegistroInformacion] FOREIGN KEY ([IdRegistroInformacion]) REFERENCES [dbo].[RegistroInformacion] ([Id])
);

