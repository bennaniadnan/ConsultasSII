-- =============================================
CREATE PROCEDURE [dbo].[COB_DELETE_COBROS_EMITIDAS_BY_IDREGISTROINFORMACION] 
	-- Add the parameters for the stored procedure here
	@IdRegistroInformacion int
AS
BEGIN
	DELETE FROM [dbo].[Cobros]
      WHERE IdRegistroInformacion = @IdRegistroInformacion AND IdEstadoCobroPago in(0, 1)--Pendiente o PendienteRespuesta
END
