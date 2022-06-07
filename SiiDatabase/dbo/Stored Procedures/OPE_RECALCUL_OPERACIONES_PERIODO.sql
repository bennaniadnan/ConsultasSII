CREATE PROCEDURE [dbo].[OPE_RECALCUL_OPERACIONES_PERIODO]
	@Ejercicio int
AS
	DELETE [Operaciones_Periodo] WHERE Ejercicio = @Ejercicio

	INSERT [Operaciones_Periodo] (Ejercicio, Periodo, Pendientes, Aceptados, ConErrores, Rechazados,IdLibroRegistro)
		SELECT @Ejercicio, p.Id, 0, 0, 0, 0, l.Id FROM [Periodo] p, LibroRegistro l
		
		
	DECLARE @IdOperacion int

	DECLARE C CURSOR FOR
	SELECT O.Id
	FROM [Operacion] O WHERE Ejercicio = @Ejercicio

	OPEN C
	
	FETCH NEXT FROM C INTO @IdOperacion
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		EXEC [OPE_UPDATE_COUNT_OPERACIONES_PERIODO] @IdOperacion

		FETCH NEXT FROM C INTO @IdOperacion

	END

	CLOSE C
	DEALLOCATE C