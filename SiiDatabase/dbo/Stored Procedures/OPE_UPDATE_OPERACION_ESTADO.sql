CREATE PROCEDURE  [dbo].[OPE_UPDATE_OPERACION_ESTADO]
(
	@Id int,
	@EstadoOperacion int,
	@ResultadoOperacion int
)
AS
BEGIN
UPDATE [Operacion]
set	idEstadoOperacion= @EstadoOperacion ,
	idResultadoOperacion = @ResultadoOperacion
  where @Id = [Id]
END





