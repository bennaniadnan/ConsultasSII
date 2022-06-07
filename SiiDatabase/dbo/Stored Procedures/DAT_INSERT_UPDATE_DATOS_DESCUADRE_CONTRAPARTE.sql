
CREATE PROCEDURE [dbo].[DAT_INSERT_UPDATE_DATOS_DESCUADRE_CONTRAPARTE]
	@IdRegistroInformacion int
AS
BEGIN
	DECLARE @SumBaseImponibleISP decimal(15,2) = 0;
	DECLARE @SumBaseImponible decimal(15,2) = 0;
	DECLARE @SumCuota decimal(15,2) = 0;
	DECLARE @SumCuotaRecargoEquivalencia decimal(15,2) = 0;
	DECLARE @ImporteTotal decimal(15,2) = 0;
	DECLARE @IdLibroRegistro varchar(2) = 0;

	SET @IdLibroRegistro = (select IdLibroRegistro FROM [dbo].[RegistroInformacion] WHERE Id = @IdRegistroInformacion);
	SET @SumBaseImponibleISP = (select SUM([BaseImponible]) from [dbo].[DetalleImportesIVA] 
		WHERE [IdRegistro] = @IdRegistroInformacion AND [IdTipoDetalleIVA] = 1);
	SET @SumBaseImponible = (select SUM([BaseImponible]) from [dbo].[DetalleImportesIVA] 
		WHERE [IdRegistro] = @IdRegistroInformacion AND [IdTipoDetalleIVA] = 0);
	IF (@IdLibroRegistro = 'FR')
	BEGIN
		SET @SumCuota = (select SUM([CuotaSoportada]) from [dbo].[DetalleImportesIVA] 
			WHERE [IdRegistro] = @IdRegistroInformacion);
	END
	ELSE IF (@IdLibroRegistro = 'FE')
	BEGIN
		SET @SumCuota = (select SUM([CuotaRepercutida]) from [dbo].[DetalleImportesIVA] 
			WHERE [IdRegistro] = @IdRegistroInformacion);
	END
	SET @SumCuotaRecargoEquivalencia = (select SUM([CuotaRecargoEquivalencia]) from [dbo].[DetalleImportesIVA] 
		WHERE [IdRegistro] = @IdRegistroInformacion);
	SET @ImporteTotal = (select ImporteTotal from [dbo].[RegistroInformacion]
		WHERE [Id] = @IdRegistroInformacion);

	IF (EXISTS(select * from [dbo].[DatosDescuadreContraparte] WHERE [IdRegistroInformacion] = @IdRegistroInformacion))
	BEGIN
		UPDATE [dbo].[DatosDescuadreContraparte]
		   SET [SumBaseImponibleISP] = @SumBaseImponibleISP
			  ,[SumBaseImponible] = @SumBaseImponible
			  ,[SumCuota] = @SumCuota
			  ,[SumCuotaRecargoEquivalencia] = @SumCuotaRecargoEquivalencia
			  ,[ImporteTotal] = @ImporteTotal
		 WHERE [IdRegistroInformacion] = @IdRegistroInformacion
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[DatosDescuadreContraparte]
			   ([IdRegistroInformacion]
			   ,[SumBaseImponibleISP]
			   ,[SumBaseImponible]
			   ,[SumCuota]
			   ,[SumCuotaRecargoEquivalencia]
			   ,[ImporteTotal])
		VALUES
			   (@IdRegistroInformacion
			   ,@SumBaseImponibleISP
			   ,@SumBaseImponible
			   ,@SumCuota
			   ,@SumCuotaRecargoEquivalencia
			   ,@ImporteTotal)
	END
END
