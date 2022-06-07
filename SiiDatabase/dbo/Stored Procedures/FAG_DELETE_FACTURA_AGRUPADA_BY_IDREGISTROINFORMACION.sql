-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FAG_DELETE_FACTURA_AGRUPADA_BY_IDREGISTROINFORMACION] 
	-- Add the parameters for the stored procedure here
	@IdRegistroInformacion int
AS
BEGIN
	DELETE FROM [dbo].[FacturasAgrupadas]
      WHERE IdRegistroInformacion = @IdRegistroInformacion
END





