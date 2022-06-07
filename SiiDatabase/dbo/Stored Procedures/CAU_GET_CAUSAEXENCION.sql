
CREATE PROCEDURE [dbo].[CAU_GET_CAUSAEXENCION](
	@IdAgencia varchar(10)	
)
AS
BEGIN
	SELECT CausaExencion, IdAgencia, Descripcion FROM dbo.CausaExencion where IdAgencia = @IdAgencia
END

