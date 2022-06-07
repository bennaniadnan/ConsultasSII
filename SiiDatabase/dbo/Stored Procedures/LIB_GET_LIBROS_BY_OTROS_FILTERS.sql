CREATE PROCEDURE [dbo].[LIB_GET_LIBROS_BY_OTROS_FILTERS]
	@IdUsuario varchar(6) = null,
	@IdLibroRegistro varchar(2),
	@Ejercicio INT = null,
	@Periodo varchar(2) = null,
	@NifContraparte varchar(20) = null,
	@IdFactura varchar(20) = null,
	@NumSerieFacturaEmisor varchar(60) = null,
	@FechaExpedicion date = null,
	@FechaRegContable date = null,
	@FechaOperacionDesde date = null,
	@FechaOperacionHasta date = null,
	@IsIDOtros bit = 0,
	@Start int = 0,
	@Records int = 20,
	@SelectedRows SelectedIds READONLY,
	@IdEstadoCuadre int = null
AS
	SELECT Id, EstadoRegistro, NumeroFactura, FechaFactura, IdFiscal, IsNifContraparte, NombreContraparte, 
		CodigoPaisContraparte, IDTypeContraparte, TipoFactura, ClaveRegimenEspecial, ImporteTotal,
		TipoNoSujeto, BaseNoSujeta, TipoDesglose, BaseExenta, CausaExencion, TipoDeSujecion,
		CuotaDeducible, Ejercicio, Periodo, IdEstadoCuadre, RefExterna, CountDetalleIVA, 
		BaseImponible, CuotaIVA, TipoRE, CuotaRE, count(*) over() as TotalCount
	FROM [Libros] with (nolock)
	WHERE IdEstadoRegistro IN(1,2)
		AND IdLibroRegistro = @IdLibroRegistro 
		AND ISNULL(Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(Ejercicio,''))
		AND ISNULL(Periodo, '') = ISNULL(@Periodo, ISNULL(Periodo,''))
		AND 
		(
			(
				case when @IsIDOtros = 1 then ISNULL(IDContraparte,'') 
					else ISNULL(NifContraparte,'') end
			) = (
				case when @IsIDOtros = 1 then ISNULL(@NifContraparte, ISNULL(IDContraparte,'')) 
					else ISNULL(@NifContraparte, ISNULL(NifContraparte,'')) end
			)
		)
		AND ISNULL(Id,'') = ISNULL(@IdFactura, ISNULL(Id,''))
		AND ISNULL(NumSerieFacturaEmisor,'') = ISNULL(@NumSerieFacturaEmisor, ISNULL(NumSerieFacturaEmisor,''))
		AND (@FechaExpedicion IS NULL OR ISNULL(FechaFactura,'') = ISNULL(CONVERT(VARCHAR(10),@FechaExpedicion,103), ISNULL(FechaFactura, '')))
		AND (@FechaRegContable IS NULL OR ISNULL(FechaRegContable,'') = ISNULL(CONVERT(VARCHAR(10),@FechaRegContable,103), ISNULL(FechaRegContable, '')))
		AND (
			ISNULL(FechaOperacion,'') BETWEEN 
			ISNULL(CONVERT(VARCHAR(10),@FechaOperacionDesde,103), ISNULL(FechaOperacion, '')) AND 
			ISNULL(CONVERT(VARCHAR(10),@FechaOperacionHasta,103), ISNULL(FechaOperacion, ''))
			)
		AND (Baja is null or Baja <> 1)
		AND IdEstadoLectura <> 2
		AND (@IdEstadoCuadre is null or IdEstadoCuadre = @IdEstadoCuadre)
		AND (NOT EXISTS(SELECT 1 FROM @SelectedRows) OR Id in (SELECT IdRegistro FROM @SelectedRows))
	ORDER BY Id desc OFFSET @Start ROWS FETCH NEXT @Records ROWS ONLY