
CREATE PROCEDURE [dbo].[ROP_INSERT_OR_UPDATE_REGISTROS_OPERACION]
(
	@IdOperacion int,
	@IdRegistroInformacion int,
	@IdEstadoRegistro int,
	@CodigoErrorRegistro int,
	@DescripcionErrorRegistro varchar(200)
)
AS
BEGIN	
if (exists(select 1 from RegistrosOperacion where IdRegistroInformacion = @IdRegistroInformacion and IdOperacion = @IdOperacion))
begin 
update RegistrosOperacion
set IdEstadoRegistro = @IdEstadoRegistro,
	CodigoErrorRegistro = @CodigoErrorRegistro,
	DescripcionErrorRegistro = @DescripcionErrorRegistro
where IdRegistroInformacion = @IdRegistroInformacion and IdOperacion = @IdOperacion
end  
ELSE
begin 
INSERT INTO RegistrosOperacion (IdOperacion, IdRegistroInformacion, IdEstadoRegistro, CodigoErrorRegistro, DescripcionErrorRegistro)
	VALUES (@IdOperacion, @IdRegistroInformacion, @IdEstadoRegistro, @CodigoErrorRegistro, @DescripcionErrorRegistro)
END
End




