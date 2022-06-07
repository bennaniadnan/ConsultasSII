CREATE PROCEDURE [dbo].[REG_COUNT_REGISTROS_APROCESAR_LIBROS]
(
	@IdUsuario varchar(6) = null,
	@IdEstadoLectura int = null,
	@IdLibroRegistro varchar(2) = null
)
AS BEGIN
	SELECT L.IdEstadoLectura, L.IdLibroRegistro, COUNT(L.Id) as CountRegistros
		FROM [dbo].[Libros] L with (nolock)
		INNER JOIN
		[dbo].EstadoRegistro ERI with (nolock)
		ON L.IdEstadoRegistro = ERI.Id
		INNER JOIN
		[dbo].LibroRegistro LR with (nolock)
		ON L.IdLibroRegistro = LR.Id
		INNER JOIN
		[dbo].Periodo PE with (nolock)
		ON L.Periodo = PE.Id
		INNER JOIN
		[dbo].Estadolectura EL with (nolock)
		ON L.IdEstadoLectura = EL.Id
		LEFT JOIN
		[dbo].Cobros CO with (nolock)
		ON L.Id= CO.IdRegistroInformacion
		LEFT JOIN
		[dbo].Pagos PA with (nolock)
		ON L.Id = PA.IdRegistroInformacion
		where (
			L.IdEstadoLectura in(1,2)
			--AND isnull(L.IdEstadoLectura,0) = isNULL(@IdEstadoLectura,isnull(L.IdEstadoLectura,0))
			--AND isnull(L.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(L.IdLibroRegistro,''))
		)
		OR (
			L.IdEstadoLectura <> 2 
			AND (CO.Nuevo = 1 OR PA.Nuevo = 1)
			--AND  isNULL(@IdEstadoLectura,0) <> 2
			--AND isnull(L.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(L.IdLibroRegistro,''))
		)
		Group by L.IdEstadoLectura, L.IdLibroRegistro
END
