
CREATE PROCEDURE [dbo].[REG_COUNT_REGISTROS_PENDIENTES_CORRECCION_LIBROS]
(
	@IdUsuario VARCHAR(6),
	@IdLibroRegistro varchar(2) = null,
	@Ejercicio INT = null
)
AS
BEGIN
	
	SELECT L.IdLibroRegistro, COUNT(distinct L.Id) as CountRegistros
	FROM RegistrosOperacion RO with (nolock)
	INNER JOIN Libros L with (nolock) ON RO.IdRegistroInformacion = L.Id
	INNER JOIN EstadoRegistro ER with (nolock) ON L.IdEstadoRegistro = ER.Id
		WHERE L.IdEstadoRegistro not in(1, 4)
		AND ISNULL(L.IdLibroRegistro, '') = ISNULL(@IdLibroRegistro, ISNULL(L.IdLibroRegistro,''))
		AND ISNULL(L.Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(L.Ejercicio,''))
		AND L.IdEstadoLectura <> 2
	GROUP BY L.IdLibroRegistro

END
