-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PAG_DELETE_PAGOS_RECIBIDAS_BY_IDREGISTROINFORMACION] 
	-- Add the parameters for the stored procedure here
	@IdRegistroInformacion int
AS
BEGIN
	DELETE FROM [dbo].[Pagos]
      WHERE IdRegistroInformacion = @IdRegistroInformacion AND IdEstadoCobroPago in(0, 1)
END
