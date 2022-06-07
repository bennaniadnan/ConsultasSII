CREATE PROCEDURE [dbo].[PAR_INSERT_UPDATE_PARAMETERS_BY_CLIENTID]
	@IdCliente int,
	@FacturasAgrupadas bit,
	@FacturasRectificadas bit,
	@CobrosRECC bit,
	@PagosRECC bit,
	@DatosComplementarios bit,
	@MultiRegistrosCatastrales bit,
	@TipoPresentacion CHAR(1),
	@Macrodato bit,
	@ForPuenteConector bit,
	@Validacion2021 bit = 0
AS
BEGIN
	IF(EXISTS(select 1 from [dbo].[Parameters] WHERE IdCliente = @IdCliente))
	BEGIN
		UPDATE [dbo].[Parameters]
		set FacturasAgrupadas = @FacturasAgrupadas,
			FacturasRectificadas = @FacturasRectificadas,
			CobrosRECC = @CobrosRECC,
			PagosRECC = @PagosRECC,
			DatosComplementarios = @DatosComplementarios,
			MultiRegistrosCatastrales = @MultiRegistrosCatastrales,
			TipoPresentacion = @TipoPresentacion,
			Macrodato = @Macrodato,
			ForPuenteConector = @ForPuenteConector
		WHERE IdCliente = @IdCliente
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Parameters](
			[IdCliente]
           ,[FacturasAgrupadas]
           ,[FacturasRectificadas]
           ,[CobrosRECC]
           ,[PagosRECC]
           ,[MultiRegistrosCatastrales]
           ,[TipoPresentacion]
           ,[DatosComplementarios]
		   ,[Macrodato]
		   ,[ForPuenteConector]
		   ,[Validacion2021])
		VALUES(
			@IdCliente,
		    @FacturasAgrupadas,
			@FacturasRectificadas,
			@CobrosRECC,
			@PagosRECC,
			@MultiRegistrosCatastrales,
			@TipoPresentacion,
			@DatosComplementarios,
			@Macrodato,
			@ForPuenteConector,
			@Validacion2021)
	END
END
