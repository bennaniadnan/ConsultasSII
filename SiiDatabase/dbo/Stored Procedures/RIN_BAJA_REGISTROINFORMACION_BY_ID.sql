CREATE PROCEDURE [dbo].[RIN_BAJA_REGISTROINFORMACION_BY_ID] 
(
	@IdOperacion int,
	@IdRegistroInformacion int
)
AS
BEGIN  
DECLARE @T Table (Id int) 
UPDATE RegistroInformacion
SET IdEstadoLectura = 2
	OUTPUT inserted.Id
	INTO @T
WHERE Id = @IdRegistroInformacion  

SELECT * FROM @T

END

