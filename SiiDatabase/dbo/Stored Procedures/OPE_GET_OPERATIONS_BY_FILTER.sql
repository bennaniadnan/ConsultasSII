
CREATE PROCEDURE  [dbo].[OPE_GET_OPERATIONS_BY_FILTER]
(
	@IdUsuario VARCHAR(6),
	@IdOperacion int = null,
	@IdTipoOperacion VARCHAR(2) = null,
	@IdLibroRegistro VARCHAR(2) = null,
	@Fecha datetime = null,
	@IdEstadoOperacion int = null,
	@IdResultadoOperacion int = null,
	@Periodo varchar(2) = null,
	@Ejercicio int = null
)
AS
BEGIN
SELECT op.Id AS IdOperacion,
		op.IdTipoOperacion,
		dbo.TipoOperacion.Denominacion AS TipoOperacionDenominacion,
		op.IdLibroRegistro, 
        dbo.LibroRegistro.Descripcion AS LibroRegistroDescripcion,
		op.IdUsuario,
		dbo.Usuario.Email,
		dbo.Usuario.UserName,
		op.IdEstadoOperacion, 
        dbo.EstadoOperacion.Descripcion AS EstadoOperacionDescripcion,
		op.IdResultadoOperacion,
		dbo.ResultadoOperacion.Descripcion AS ResultadoOperacionDescripcion,
		EstadoOperacion.Orden as EstadoOperacionOrden, ResultadoOperacion.Orden as ResultadoOperacionOrden,
		op.FechaOperacion,HoraOperacion,
		op.CSV,
		op.Pendientes as NRegistrosPendientes,
		op.Aceptados as NRegistrosAceptados,
		op.AceptadosCondicionados as NRegistrosAceptadosCondicionados,
		op.Rechazados as NRegistrosRechazados
		--count(case when RO.IdEstadoRegistro LIKE 0 then 1 end) as NRegistrosPendientes, 
		--count(case when RO.IdEstadoRegistro LIKE 1 then 1 end) as NRegistrosAceptados,
		--count(case when RO.IdEstadoRegistro LIKE 2 then 1 end) as NRegistrosAceptadosCondicionados,
		--count(case when RO.IdEstadoRegistro LIKE 3 then 1 end) as NRegistrosRechazados
FROM Operacion op with (nolock)
INNER JOIN RegistrosOperacion RO with (nolock) ON op.Id = RO.IdOperacion INNER JOIN 
	dbo.TipoOperacion with (nolock)  ON op.IdTipoOperacion = dbo.TipoOperacion.Id INNER JOIN 
    dbo.LibroRegistro with (nolock) ON op.IdLibroRegistro = dbo.LibroRegistro.Id INNER JOIN
    dbo.EstadoOperacion with (nolock) ON op.IdEstadoOperacion = dbo.EstadoOperacion.Id INNER JOIN
    dbo.ResultadoOperacion with (nolock) ON op.IdResultadoOperacion = dbo.ResultadoOperacion.Id INNER JOIN
    dbo.Usuario with (nolock) ON op.IdUsuario = dbo.Usuario.UserId
WHERE   (@IdOperacion = 0 OR isnull(op.Id,0) = isNULL(@IdOperacion,isnull(op.Id,0)))
		AND isnull(op.IdTipoOperacion,'') = isNULL(@IdTipoOperacion,isnull(op.IdTipoOperacion,''))
		AND isnull(op.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(op.IdLibroRegistro,''))
		AND isnull(op.Periodo,'') = isNULL(@Periodo,isnull(op.Periodo,''))
		AND isnull(op.Ejercicio,0) = isNULL(@Ejercicio,isnull(op.Ejercicio,0))
		AND isnull(op.IdTipoOperacion,'') = isNULL(@IdTipoOperacion,isnull(op.IdTipoOperacion,''))
		AND isnull(op.IdEstadoOperacion,0) = isNULL(@IdEstadoOperacion,isnull(op.IdEstadoOperacion,0))
		AND isnull(op.IdResultadoOperacion,0) = isNULL(@IdResultadoOperacion,isnull(op.IdResultadoOperacion,0))
		AND isnull(op.FechaOperacion,'19000101') = isNULL(@Fecha,isnull(op.FechaOperacion,'19000101'))
		
Group by op.Id, op.IdTipoOperacion, dbo.TipoOperacion.Denominacion, op.IdLibroRegistro, 
         dbo.LibroRegistro.Descripcion, op.IdUsuario, dbo.Usuario.Email, dbo.Usuario.UserName, op.IdCliente, op.IdEstadoOperacion, 
         dbo.EstadoOperacion.Descripcion, op.IdResultadoOperacion, dbo.ResultadoOperacion.Descripcion,EstadoOperacion.Orden, ResultadoOperacion.Orden
		 ,EstadoOperacion.Orden, ResultadoOperacion.Orden, op.FechaOperacion,HoraOperacion,op.CSV,
		 op.Pendientes, op.Aceptados, op.AceptadosCondicionados, op.Rechazados
Order by 	EstadoOperacion.Orden, ResultadoOperacion.Orden, op.FechaOperacion
END