CREATE PROCEDURE [dbo].[REG_UPDATE_REGISTRO_INFORMACION_FECHA_FIN_PLAZO_BY_TABLE]
	@RegistrosFecha TableRegistroFecha READONLY
AS
    --DECLARE @ListRegistros TableRegistroFecha
    --INSERT INTO @ListRegistros VALUES (1, '22-10-2019'),(1, '22-10-2019')

    --Select '(%d, %s),', r.Id, r.FechaFinPlazo from RegistroInformacion r where r.FechaFinPlazo is not null and r.FechaFinPlazo = ''

	UPDATE RegistroInformacion
SET
    RegistroInformacion.FechaFinPlazo = Registros.FechaFinPlazo
FROM
    @RegistrosFecha AS Registros
WHERE
    RegistroInformacion.Id = Registros.IdRegistro