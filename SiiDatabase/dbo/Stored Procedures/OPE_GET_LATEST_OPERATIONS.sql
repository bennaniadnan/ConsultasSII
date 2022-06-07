CREATE PROCEDURE  [dbo].[OPE_GET_LATEST_OPERATIONS]
(
	@IdUsuario VARCHAR(6),
	@vTop int = 5
)
AS
BEGIN
SELECT TOP(@vTop) op.Id,
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
FROM Operacion op with (nolock)
    INNER JOIN dbo.TipoOperacion with (nolock)  ON op.IdTipoOperacion = dbo.TipoOperacion.Id
    INNER JOIN dbo.LibroRegistro with (nolock) ON op.IdLibroRegistro = dbo.LibroRegistro.Id 
    INNER JOIN dbo.EstadoOperacion with (nolock) ON op.IdEstadoOperacion = dbo.EstadoOperacion.Id 
    INNER JOIN dbo.ResultadoOperacion with (nolock) ON op.IdResultadoOperacion = dbo.ResultadoOperacion.Id 
 
	 --where @IdUsuario = op.IdUsuario
	ORDER BY op.FechaOperacion desc, op.HoraOperacion desc

END
