
CREATE PROCEDURE [dbo].[REG_COUNT_REGISTROS_PENDIENTES_CORRECCION]
(
	@IdUsuario VARCHAR(6),
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
	
	SELECT RI.IdLibroRegistro, COUNT(distinct RI.Id) as CountRegistros
	FROM Operacion OP with (nolock) 
	INNER JOIN RegistrosOperacion RO with (nolock) ON OP.Id = RO.IdOperacion
	INNER JOIN RegistroInformacion RI with (nolock) ON RO.IdRegistroInformacion = RI.Id
	INNER JOIN EstadoRegistro ER with (nolock) ON RI.IdEstadoRegistro = ER.Id
		WHERE RI.IdEstadoRegistro not in(1, 4)
		AND ISNULL(RI.IdLibroRegistro, '') = ISNULL(@IdLibroRegistro, ISNULL(RI.IdLibroRegistro,''))
		AND ISNULL(RI.Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(RI.Ejercicio,''))
		AND RI.IdEstadoLectura <> 2
	GROUP BY RI.IdLibroRegistro

END
