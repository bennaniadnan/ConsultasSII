CREATE PROCEDURE [dbo].[REG_UPDATE_ESTADO_LECTURA_TO_PROCESSADA]
(
	@IdLibroRegistro varchar(2),
	@IdEstadoLectura int,
	@Id int = null
)
AS
BEGIN	

UPDATE RI
SET RI.IdEstadoLectura = 3
FROM RegistroInformacion RI
LEFT JOIN Cobros CO ON RI.Id = CO.IdRegistroInformacion AND CO.Nuevo = 1
LEFT JOIN Pagos PA ON RI.Id = PA.IdRegistroInformacion AND PA.Nuevo = 1
WHERE ((IdEstadoLectura = @IdEstadoLectura OR IdEstadoLectura = 0 AND RI.Id in (PA.IdRegistroInformacion, CO.IdRegistroInformacion)) 
	AND IdLibroRegistro = @IdLibroRegistro
	AND ISNULL(RI.Id, 0) = ISNULL(@Id, ISNULL(RI.Id, 0)));

UPDATE CO
SET CO.IdEstadoCobroPago = 1
FROM RegistroInformacion RI
JOIN Cobros CO ON RI.Id = CO.IdRegistroInformacion AND CO.Nuevo = 1 AND CO.IdEstadoCobroPago = 0
WHERE ((IdEstadoLectura = @IdEstadoLectura OR (IdEstadoLectura in(0,3) AND RI.Id = CO.IdRegistroInformacion)) 
	AND @IdEstadoLectura <> 2
	AND IdLibroRegistro = @IdLibroRegistro
	AND ISNULL(RI.Id, 0) = ISNULL(@Id, ISNULL(RI.Id, 0)));
	
UPDATE PA
SET PA.IdEstadoCobroPago = 1
FROM RegistroInformacion RI
JOIN Pagos PA ON RI.Id = PA.IdRegistroInformacion AND PA.Nuevo = 1 AND PA.IdEstadoCobroPago = 0
WHERE ((IdEstadoLectura = @IdEstadoLectura OR (IdEstadoLectura in(0,3) AND RI.Id = PA.IdRegistroInformacion)) 
	AND @IdEstadoLectura <> 2
	AND IdLibroRegistro = @IdLibroRegistro
	AND ISNULL(RI.Id, 0) = ISNULL(@Id, ISNULL(RI.Id, 0)));
END
