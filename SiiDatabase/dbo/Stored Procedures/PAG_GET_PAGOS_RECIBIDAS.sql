-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PAG_GET_PAGOS_RECIBIDAS] 
	@IdRegistroInformacion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT *
  FROM [dbo].[Pagos] with (nolock)
  WHERE [IdRegistroInformacion] = @IdRegistroInformacion
END

