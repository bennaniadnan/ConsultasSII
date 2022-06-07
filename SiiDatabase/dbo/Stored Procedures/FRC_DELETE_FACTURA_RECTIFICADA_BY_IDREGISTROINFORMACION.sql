-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FRC_DELETE_FACTURA_RECTIFICADA_BY_IDREGISTROINFORMACION] 
	-- Add the parameters for the stored procedure here
	@IdRegistroInformacion int
AS
BEGIN
	DELETE FROM [dbo].[FacturasRectificadas]
      WHERE IdRegistroInformacion = @IdRegistroInformacion
END





