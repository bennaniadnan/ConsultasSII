CREATE TRIGGER [TRIGGER_UPDATE_DETALLE_IVA]
ON [dbo].[DetalleImportesIVA]
AFTER INSERT, UPDATE
AS
BEGIN
	IF OBJECT_ID(N'dbo.Libros', N'U') IS NOT NULL
	BEGIN
		
		DECLARE @IdRegistro int, @BaseImponible decimal(15,2), @CuotaIVA decimal(15,2), @TipoRE decimal(15,2), @CuotaRE decimal(15,2) 
		SELECT @IdRegistro = IdRegistro FROM INSERTED
		SELECT 
		@BaseImponible = ISNULL(SUM(DI.BaseImponible),0),
		@CuotaIVA = ISNULL(SUM(CASE WHEN RI.IdLibroRegistro LIKE 'FE' THEN DI.CuotaRepercutida ELSE DI.CuotaSoportada END),0),
		@TipoRE = ISNULL(SUM(DI.TipoRecargoEquivalencia),0),
		@CuotaRE = ISNULL(SUM(DI.CuotaRecargoEquivalencia),0)
			FROM RegistroInformacion RI with (nolock)
		LEFT JOIN DetalleImportesIVA DI with (nolock) ON RI.Id = DI.IdRegistro
		LEFT JOIN DatosComplementarios DC  with (nolock) ON RI.Id = DC.IdRegistroInformacion
		WHERE RI.Id = @IdRegistro

		UPDATE [Libros] SET BaseImponible = @BaseImponible, CuotaIVA = @CuotaIVA, TipoRE = @TipoRE, CuotaRE = @CuotaRE
		WHERE Id = @IdRegistro
	END
	ELSE
		PRINT 'Table Libros Not Exists'
END