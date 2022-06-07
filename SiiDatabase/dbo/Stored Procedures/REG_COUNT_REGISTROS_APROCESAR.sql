CREATE PROCEDURE [dbo].[REG_COUNT_REGISTROS_APROCESAR]
(
	@IdUsuario varchar(6) = null,
	@IdEstadoLectura int = null,
	@IdLibroRegistro varchar(2) = null
)
AS BEGIN
	SELECT RI.IdEstadoLectura as IdEstadoLectura, COUNT(RI.[Id]) as CountRegistros
		FROM [dbo].[RegistroInformacion] RI with (nolock)
		INNER JOIN
		[dbo].EstadoRegistro ERI with (nolock)
		ON RI.IdEstadoRegistro = ERI.Id
		INNER JOIN
		[dbo].LibroRegistro LR with (nolock)
		ON RI.IdLibroRegistro = LR.Id
		INNER JOIN
		[dbo].Periodo PE with (nolock)
		ON RI.Periodo = PE.Id
		INNER JOIN
		[dbo].Estadolectura EL with (nolock)
		ON RI.IdEstadoLectura = EL.Id
		LEFT JOIN
		[dbo].Cobros CO with (nolock)
		ON RI.Id= CO.IdRegistroInformacion
		LEFT JOIN
		[dbo].Pagos PA with (nolock)
		ON RI.Id = PA.IdRegistroInformacion
		where (
			RI.IdEstadoLectura in(1,2)
			AND isnull(RI.IdEstadoLectura,0) = isNULL(@IdEstadoLectura,isnull(RI.IdEstadoLectura,0))
			AND isnull(RI.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(RI.IdLibroRegistro,''))
		)
		OR (
			RI.IdEstadoLectura <> 2 
			AND  isNULL(@IdEstadoLectura,0) <> 2
			AND (CO.Nuevo = 1 OR PA.Nuevo = 1)
			AND isnull(RI.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(RI.IdLibroRegistro,''))
		)
		Group by RI.IdEstadoLectura
END
