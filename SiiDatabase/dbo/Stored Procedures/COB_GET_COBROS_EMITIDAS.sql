-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[COB_GET_COBROS_EMITIDAS] 
	@IdRegistroInformacion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT *
  FROM [dbo].[Cobros] with (nolock)
  WHERE [IdRegistroInformacion] = @IdRegistroInformacion
END

