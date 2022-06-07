CREATE PROCEDURE [dbo].[PER_GET_PERIODOS_BY_TIPOPRESENTACION]-- 'M' 
	@TipoPresentacion CHAR
AS
BEGIN
	SELECT Id, Texte, TipoPresentacion FROM Periodo WHERE TipoPresentacion = @TipoPresentacion OR TipoPresentacion = 'A'
	Order by TipoPresentacion desc, Id 
END

