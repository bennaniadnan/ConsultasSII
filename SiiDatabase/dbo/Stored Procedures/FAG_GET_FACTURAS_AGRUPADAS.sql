-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FAG_GET_FACTURAS_AGRUPADAS]
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
  FROM [dbo].[FacturasAgrupadas] with (nolock)
  WHERE [IdRegistroInformacion] = @IdRegistroInformacion
END





