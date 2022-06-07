-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FRC_GET_FACTURAS_RECTIFICADAS]
	@IdRegistroInformacion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [Id]
      ,[IdRegistroInformacion]
      ,[NumSerieFacturaEmisor]
      ,[FechaExpedicionFacturaEmisor]
  FROM [dbo].[FacturasRectificadas] with (nolock)
  WHERE [IdRegistroInformacion] = @IdRegistroInformacion
END





