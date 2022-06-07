

CREATE PROCEDURE [dbo].[DII_DELETE_DETALLE_IMPORTESIVA_BY_IDREGISTROINFORMACION] 
	-- Add the parameters for the stored procedure here
	@IdRegistroInformacion int
AS
BEGIN
	DELETE FROM [dbo].[DetalleImportesIVA]
      WHERE IdRegistro = @IdRegistroInformacion
END



