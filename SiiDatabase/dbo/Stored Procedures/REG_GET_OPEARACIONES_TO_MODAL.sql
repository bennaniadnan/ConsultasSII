
CREATE PROCEDURE [dbo].[REG_GET_OPEARACIONES_TO_MODAL]
(
	@IdUsuario varchar(6),
	@IdRegistroInformacion int
)
AS
BEGIN
	SELECT DISTINCT
		OP.Id AS IdOperacion
		,OP.IdTipoOperacion
		,TipoOP.Denominacion AS TipoOperacionDenominacion
		,OP.IdLibroRegistro
        ,LR.Descripcion AS LibroRegistroDescripcion
		,OP.IdEstadoOperacion 
        ,EO.Descripcion AS EstadoOperacionDescripcion
		,CONVERT(VARCHAR(10),OP.FechaOperacion,103) AS FechaOperacion
		,OP.HoraOperacion
		,OP.CSV
		,RO.IdEstadoRegistro as IdResultadoOperacion
		,ER.Descripcion AS ResultadoOperacionDescripcion
		,RO.CodigoErrorRegistro
		,RO.DescripcionErrorRegistro
	FROM Operacion OP
	INNER JOIN TipoOperacion TipoOP
		ON OP.IdTipoOperacion = TipoOP.Id
	INNER JOIN LibroRegistro LR
		ON OP.IdLibroRegistro = LR.Id
	INNER JOIN EstadoOperacion EO
		ON EO.Id = OP.IdEstadoOperacion
	INNER JOIN RegistrosOperacion RO
		ON OP.Id = RO.IdOperacion
	LEFT JOIN EstadoRegistro ER
		ON ER.Id = RO.IdEstadoRegistro
	INNER JOIN RegistroInformacion RI
		ON RO.IdRegistroInformacion = RI.Id
	WHERE RI.Id = @IdRegistroInformacion
END

