CREATE PROCEDURE [dbo].[OPR_INSERT_OR_UPDATE_OPERACION] 
(
	@Id int = null,
	@IdTipoOperacion varchar(2),
	@IdUsuario varchar(6),
	@IdCliente int,
	@IdEstadoOperacion int,
	@IdResultadoOperacion int,
	@IdLibroregistro varchar(2),
	@Ejercicio int,
	@Periodo varchar(2),
	@FechaEntrada date,
	@HoraEntrada time(0),
	@FechaOperacion date,
	@HoraOperacion time(0),
	@CSV varchar(30),
	@XmlEnviada varchar(100),
	@XmlRespuesta varchar(100)
)
AS
BEGIN
if @Id is not null and (exists(select 1 from OPERACION where Id = @Id))
begin 
update OPERACION
set
	IdEstadoOperacion = @IdEstadoOperacion,
	IdResultadoOperacion = @IdResultadoOperacion,
	FechaOperacion = @FechaOperacion,
	HoraOperacion = @HoraOperacion,
	CSV = @CSV,
	XmlEnviada = @XmlEnviada,
	XmlRespuesta = @XmlRespuesta
	output inserted.Id
where @Id = Id
end 
else 
begin
INSERT INTO Operacion (IdTipoOperacion, IdUsuario, IdCliente,
		IdEstadoOperacion, IdResultadoOperacion,IdLibroregistro,
		Ejercicio, Periodo, FechaEntrada, HoraEntrada,
		FechaOperacion, HoraOperacion, CSV, XmlEnviada, XmlRespuesta)
	VALUES(@IdTipoOperacion, @IdUsuario, @IdCliente,
		@IdEstadoOperacion, @IdResultadoOperacion,@IdLibroregistro,
		@Ejercicio, @Periodo, @FechaEntrada, @HoraEntrada,
		@FechaOperacion, @HoraOperacion, @CSV, @XmlEnviada, @XmlRespuesta)
	select SCOPE_IDENTITY()
end
END

