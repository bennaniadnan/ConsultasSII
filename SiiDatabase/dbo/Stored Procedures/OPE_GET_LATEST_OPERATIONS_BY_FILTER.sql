
CREATE PROCEDURE [dbo].[OPE_GET_LATEST_OPERATIONS_BY_FILTER]
(
	@IdUsuario VARCHAR(6),
	@Id int = null,
	@Ejercicio int = null,
	@Periodo VARCHAR(2) = null,
	@FechaOperacionFrom DATE = null,
	@FechaOperacionTo DATE = null,
	@LibroRegistro VARCHAR(2) = null,
	@TipoOperacion VARCHAR(2) = null,
	@ResultadoOperacion int = null,
	@PageNumber int = 1,
	@Start int = 0,
	@Records int = 20
)
AS
BEGIN

	DECLARE @Offset int = (@PageNumber - 1) * @Records, @top int = @PageNumber * @Records, @count int = 0

	SELECT @count = COUNT(distinct op.Id)
	FROM Operacion op with (nolock)
	--INNER JOIN RegistrosOperacion RO with (nolock) ON op.Id = RO.IdOperacion
	--	INNER JOIN RegistroInformacion RI with (nolock) ON RO.IdRegistroInformacion = RI.Id
		--INNER JOIN dbo.TipoOperacion with (nolock)  ON op.IdTipoOperacion = dbo.TipoOperacion.Id
		--INNER JOIN dbo.LibroRegistro with (nolock) ON op.IdLibroRegistro = dbo.LibroRegistro.Id 
		--INNER JOIN dbo.EstadoOperacion with (nolock) ON op.IdEstadoOperacion = dbo.EstadoOperacion.Id 
		--INNER JOIN dbo.ResultadoOperacion with (nolock) ON op.IdResultadoOperacion = dbo.ResultadoOperacion.Id 
 
		 where @IdUsuario = op.IdUsuario
			AND ISNULL(OP.Id, '') = ISNULL(@Id, ISNULL(OP.Id,''))
			AND ISNULL(OP.Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(OP.Ejercicio,''))
			AND ISNULL(OP.Periodo, '') = ISNULL(@Periodo, ISNULL(OP.Periodo,''))
			AND (
				(OP.FechaOperacion >= @FechaOperacionFrom OR @FechaOperacionFrom IS NULL) 
				AND (OP.FechaOperacion < DATEADD(day,1,@FechaOperacionTo) OR @FechaOperacionTo IS NULL)
			)
			AND ISNULL(OP.IdLibroRegistro, '') = ISNULL(@LibroRegistro, ISNULL(OP.IdLibroRegistro,''))
			AND ISNULL(OP.IdTipoOperacion, '') = ISNULL(@TipoOperacion, ISNULL(OP.IdTipoOperacion,''))
			AND ISNULL(OP.IdResultadoOperacion, '') = ISNULL(@ResultadoOperacion, ISNULL(OP.IdResultadoOperacion,''))
	


	SELECT TOP(@top) 
		op.Id,
		op.Ejercicio,
		op.Periodo,
		convert(varchar,op.FechaOperacion,103) AS FechaOperacion,
		op.HoraOperacion,
		op.IdTipoOperacion,
		CASE WHEN op.IdTipoOperacion IN('A0', 'A5') THEN 'Alta' 
			ELSE (CASE WHEN op.IdTipoOperacion IN ('A1', 'A4', 'A6') THEN 'Modif' 
				ELSE (CASE WHEN op.IdTipoOperacion = 'BJ' THEN 'Baja' 
					ELSE (CASE WHEN op.IdTipoOperacion = 'C1' THEN 'Cobros' 
						ELSE (CASE WHEN op.IdTipoOperacion = 'P1' THEN 'Pagos' 
						ELSE dbo.TipoOperacion.Denominacion 
						END) 
					END) 
				END) 
			END) 
		END AS TipoOperacionDenominacion,
		op.IdLibroRegistro, 
        dbo.LibroRegistro.Descripcion AS LibroRegistroDescripcion, 
        op.IdEstadoOperacion, 
        dbo.EstadoOperacion.Descripcion AS EstadoOperacionDescripcion, 
        op.IdResultadoOperacion, 
        dbo.ResultadoOperacion.Descripcion AS ResultadoOperacionDescripcion,
		op.Pendientes as NRegistrosPendientes, 
		op.Aceptados as NRegistrosAceptados,
		op.AceptadosCondicionados as NRegistrosAceptadosCondicionados,
		op.Rechazados as NRegistrosRechazados
		into #tmp
	FROM Operacion op with (nolock)
	--INNER JOIN RegistrosOperacion RO with (nolock) ON op.Id = RO.IdOperacion
	--	INNER JOIN RegistroInformacion RI with (nolock) ON RO.IdRegistroInformacion = RI.Id
		INNER JOIN dbo.TipoOperacion with (nolock)  ON op.IdTipoOperacion = dbo.TipoOperacion.Id
		INNER JOIN dbo.LibroRegistro with (nolock) ON op.IdLibroRegistro = dbo.LibroRegistro.Id 
		INNER JOIN dbo.EstadoOperacion with (nolock) ON op.IdEstadoOperacion = dbo.EstadoOperacion.Id 
		INNER JOIN dbo.ResultadoOperacion with (nolock) ON op.IdResultadoOperacion = dbo.ResultadoOperacion.Id

		where @IdUsuario = op.IdUsuario
			AND ISNULL(OP.Id, '') = ISNULL(@Id, ISNULL(OP.Id,''))
			AND ISNULL(OP.Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(OP.Ejercicio,''))
			AND ISNULL(OP.Periodo, '') = ISNULL(@Periodo, ISNULL(OP.Periodo,''))
			AND (
				(OP.FechaOperacion >= @FechaOperacionFrom OR @FechaOperacionFrom IS NULL) 
				AND (OP.FechaOperacion < DATEADD(day,1,@FechaOperacionTo) OR @FechaOperacionTo IS NULL)
			)
			AND ISNULL(OP.IdLibroRegistro, '') = ISNULL(@LibroRegistro, ISNULL(OP.IdLibroRegistro,''))
			AND ISNULL(OP.IdTipoOperacion, '') = ISNULL(@TipoOperacion, ISNULL(OP.IdTipoOperacion,''))
			AND ISNULL(OP.IdResultadoOperacion, '') = ISNULL(@ResultadoOperacion, ISNULL(OP.IdResultadoOperacion,''))
		ORDER BY OP.Id desc, OP.FechaOperacion desc, OP.HoraOperacion desc

	select *, @count as TotalCount--, count(*) over() as TotalCount 
	from #tmp  
		ORDER BY #tmp.Id desc, #tmp.FechaOperacion desc, #tmp.HoraOperacion desc OFFSET @Offset ROWS FETCH NEXT @Records ROWS ONLY
	Drop table #tmp
END