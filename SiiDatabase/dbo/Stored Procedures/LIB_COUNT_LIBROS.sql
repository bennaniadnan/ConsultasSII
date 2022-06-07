CREATE PROCEDURE [dbo].[LIB_COUNT_LIBROS]
(
	@IdUsuario VARCHAR(6) = null,
	@Ejercicio INT = null,
	@IdLibroRegistro varchar(2) = null,
	@Periodo varchar(2) = null
	
)
AS
BEGIN
	
	SELECT RI.IdLibroRegistro, COUNT(RI.Id) as CountRegistros, SUM(RI.BaseImponible) as BaseImponible, SUM(RI.CuotaIVA) as CuotaIVA
	from Libros RI with(nolock)
	where RI.Ejercicio = @Ejercicio 
	GROUP BY RI.IdLibroRegistro
	--AND (@IdLibroRegistro IS NULL OR @IdLibroRegistro = RI.IdLibroRegistro)

END