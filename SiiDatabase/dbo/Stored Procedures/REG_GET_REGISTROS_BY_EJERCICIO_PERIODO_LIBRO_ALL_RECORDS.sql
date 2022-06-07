
Create PROCEDURE [dbo].[REG_GET_REGISTROS_BY_EJERCICIO_PERIODO_LIBRO_ALL_RECORDS]
(
	@IdUsuario varchar(6),
	@IdLibroRegistro varchar(2),
	@Ejercicio INT = null,
	@Periodo varchar(2) = null,
	@NifContraparte varchar(20) = null,
	@IdFactura varchar(20) = null,
	@NumSerieFacturaEmisor varchar(60) = null,
	@FechaExpedicion date = null,
	@FechaOperacionDesde date = null,
	@FechaOperacionHasta date = null,
	@IsIDOtros bit,
	@PageNumber int = 1,
	@Records int = 20
 )	
AS
BEGIN
	DECLARE @Offset int = (@Pagenumber - 1) * @Records

SELECT DISTINCT 
	RI.*,
	count(*) over() as TotalCount
	 FROM Operacion OP (nolock) 
	 INNER JOIN RegistrosOperacion RO with (nolock) ON OP.Id = RO.IdOperacion
	 INNER JOIN RegistroInformacion RI with (nolock) ON RO.IdRegistroInformacion = RI.Id
	 LEFT JOIN DetalleImportesIVA DI with (nolock) ON RI.Id = DI.IdRegistro
	 LEFT JOIN DatosComplementarios DC  with (nolock) ON RI.Id = DC.IdRegistroInformacion
		WHERE RI.IdEstadoRegistro IN(1,2)
		AND RI.IdLibroRegistro = @IdLibroRegistro 
		AND ISNULL(RI.Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(RI.Ejercicio,''))
		AND ISNULL(RI.Periodo, '') = ISNULL(@Periodo, ISNULL(RI.Periodo,''))
		AND 
		(
			(
				case when @IsIDOtros = 1 then ISNULL(RI.IDContraparte,'') 
					else ISNULL(RI.NifContraparte,'')end
			) = (
				case when @IsIDOtros = 1 then ISNULL(@NifContraparte, ISNULL(RI.IDContraparte,'')) 
					else ISNULL(@NifContraparte, ISNULL(RI.NifContraparte,''))end
			)
		)
		--AND ISNULL(@NifContraparte,isnull(RI.NifContraparte,isnull(RI.IDContraparte,''))) = isnull(RI.NifContraparte,isnull(RI.IDContraparte,'')) 
		AND ISNULL(RI.Id,'') = ISNULL(@IdFactura, ISNULL(RI.Id,''))
		AND ISNULL(RI.NumSerieFacturaEmisor,'') = ISNULL(@NumSerieFacturaEmisor, ISNULL(RI.NumSerieFacturaEmisor,''))
		AND ISNULL(RI.FechaExpedicionFacturaEmisor,'') = ISNULL(@FechaExpedicion, ISNULL(RI.FechaExpedicionFacturaEmisor, ''))
		AND (
			ISNULL(RI.FechaOperacion,'') BETWEEN 
			ISNULL(@FechaOperacionDesde, ISNULL(RI.FechaOperacion, '')) AND 
			ISNULL(@FechaOperacionHasta, ISNULL(RI.FechaOperacion, ''))
			)
		AND OP.IdUsuario = @IdUsuario
		AND (RI.Baja is null or RI.Baja!=1)
		AND RI.IdEstadoLectura <> 2
		ORDER BY RI.Id OFFSET @Offset ROWS FETCH NEXT @Records ROWS ONLY
		
END

