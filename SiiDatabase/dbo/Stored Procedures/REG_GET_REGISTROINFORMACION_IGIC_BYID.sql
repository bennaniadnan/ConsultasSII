
CREATE PROCEDURE [dbo].[REG_GET_REGISTROINFORMACION_IGIC_BYID](
	@IdRegistroInformacion int
)
AS
BEGIN
	SELECT IdRegistroInformacion as Id, PagoAnticipado, IdTipoBienOperacion, IdTipoDocumentoArt25, NumeroProtocolo, NombreNotario 
		FROM RegistroInformacion_IGIC 
			where IdRegistroInformacion = @IdRegistroInformacion
END

