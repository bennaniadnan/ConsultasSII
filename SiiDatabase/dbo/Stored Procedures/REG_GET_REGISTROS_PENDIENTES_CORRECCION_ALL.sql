
CREATE PROCEDURE [dbo].[REG_GET_REGISTROS_PENDIENTES_CORRECCION_ALL]
(
	@IdUsuario VARCHAR(6) = null,
	@IdLibroRegistro varchar(2) = null,
	@Ejercicio INT = null,
	@Periodo varchar(2) = null,
	@NifContraparte varchar(20) = null,
	@IdFactura varchar(20) = null,
	@NumSerieFacturaEmisor varchar(60) = null,
	@PageNumber int = 1,
	@Records int = 20
)
AS
BEGIN
	--DECLARE @Offset int = (@Pagenumber - 1) * @Records, @top int = @Pagenumber * @Records , @count int = 0
	
	--SELECT @count = COUNT(distinct RI.Id)
	--FROM Operacion OP with (nolock) 
	--INNER JOIN RegistrosOperacion RO with (nolock) ON OP.Id = RO.IdOperacion
	--INNER JOIN RegistroInformacion RI with (nolock) ON RO.IdRegistroInformacion = RI.Id
	--INNER JOIN EstadoRegistro ER with (nolock) ON RI.IdEstadoRegistro = ER.id
	--	WHERE RI.IdEstadoRegistro not in(1, 4)
	--	AND ISNULL(RI.IdLibroRegistro, '') = ISNULL(@IdLibroRegistro, ISNULL(RI.IdLibroRegistro,''))
	--	AND ISNULL(RI.Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(RI.Ejercicio,''))
	--	AND ISNULL(RI.Periodo, '') = ISNULL(@Periodo, ISNULL(RI.Periodo,''))
	--	AND ISNULL(@NifContraparte,isnull(RI.NifContraparte,isnull(RI.IDContraparte,''))) = isnull(RI.NifContraparte,isnull(RI.IDContraparte,'')) 
	--	AND ISNULL(RI.Id,'') = ISNULL(@IdFactura, ISNULL(RI.Id,''))
	--	AND ISNULL(RI.NumSerieFacturaEmisor,'') = ISNULL(@NumSerieFacturaEmisor, ISNULL(RI.NumSerieFacturaEmisor,''))
	--	AND OP.IdUsuario = @IdUsuario
	--	AND RI.IdEstadoLectura <> 2

SELECT DISTINCT --TOP(@top)
	RI.Id AS Id,
	RI.Ejercicio,
	RI.Periodo,
	RI.IdLibroRegistro,
	isnull(nullif(RI.NifContraparte,''),RI.IDContraparte) AS Nif_ID_Emisor,
	RI.NumSerieFacturaEmisor AS NumeroFactura,
	CONVERT(VARCHAR(10),RI.FechaExpedicionFacturaEmisor,103) AS FechaFactura,
	RI.TipoFactura,
	RI.ImporteTotal,
	ER.Descripcion AS EstadoRegistro
	--into #tmp
	FROM Operacion OP with (nolock) 
	INNER JOIN RegistrosOperacion RO with (nolock) ON OP.Id = RO.IdOperacion
	INNER JOIN RegistroInformacion RI with (nolock) ON RO.IdRegistroInformacion = RI.Id
	INNER JOIN EstadoRegistro ER with (nolock) ON RI.IdEstadoRegistro = ER.id
		WHERE RI.IdEstadoRegistro not in(1, 4)
		AND ISNULL(RI.IdLibroRegistro, '') = ISNULL(@IdLibroRegistro, ISNULL(RI.IdLibroRegistro,''))
		AND ISNULL(RI.Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(RI.Ejercicio,''))
		AND ISNULL(RI.Periodo, '') = ISNULL(@Periodo, ISNULL(RI.Periodo,''))
		AND ISNULL(@NifContraparte,isnull(RI.NifContraparte,isnull(RI.IDContraparte,''))) = isnull(RI.NifContraparte,isnull(RI.IDContraparte,'')) 
		AND ISNULL(RI.Id,'') = ISNULL(@IdFactura, ISNULL(RI.Id,''))
		AND ISNULL(RI.NumSerieFacturaEmisor,'') = ISNULL(@NumSerieFacturaEmisor, ISNULL(RI.NumSerieFacturaEmisor,''))
		--AND OP.IdUsuario = @IdUsuario
		AND RI.IdEstadoLectura <> 2
	order by RI.Id desc
		
	--SELECT * , @count as TotalCount --, count(*) over() as TotalCount 
	--from #tmp
	--	ORDER BY #tmp.Id OFFSET @Offset ROWS FETCH NEXT @Records ROWS ONLY

	--Drop table #tmp
END
