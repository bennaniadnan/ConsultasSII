CREATE PROCEDURE [dbo].[REG_INSERT_UPDATE_REGISTROINFORMACION_IGIC]
	@IdRegistroInformacion int = 0,
	@PagoAnticipado char(1)  = null,
	@IdTipoBienOperacion varchar(2) = null,
	@IdTipoDocumentoArt25 varchar(2) = null,
	@NumeroProtocolo varchar(6) = null,
	@NombreNotario varchar(120) = null
AS
BEGIN
	IF (EXISTS(select * from [dbo].RegistroInformacion_IGIC WHERE [IdRegistroInformacion] = @IdRegistroInformacion))
	BEGIN
		UPDATE [dbo].RegistroInformacion_IGIC
		   SET PagoAnticipado = @PagoAnticipado
			  ,IdTipoBienOperacion = @IdTipoBienOperacion
			  ,IdTipoDocumentoArt25 = @IdTipoDocumentoArt25
			  ,NumeroProtocolo = @NumeroProtocolo
			  ,NombreNotario = @NombreNotario
			  OUTPUT inserted.IdRegistroInformacion
		 WHERE [IdRegistroInformacion] = @IdRegistroInformacion
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].RegistroInformacion_IGIC
			   ([IdRegistroInformacion]
			   ,PagoAnticipado
			   ,IdTipoBienOperacion
			   ,IdTipoDocumentoArt25
			   ,NumeroProtocolo
			   ,NombreNotario)
		VALUES
			   (@IdRegistroInformacion
			   ,@PagoAnticipado
			   ,@IdTipoBienOperacion
			   ,@IdTipoDocumentoArt25
			   ,@NumeroProtocolo
			   ,@NombreNotario)
		select SCOPE_IDENTITY();
	END
END

