
CREATE PROCEDURE [dbo].[OPE_GET_OPERATIONS_BY_CSV] (
	@CSV varchar(30)
)
AS
BEGIN
	select * from Operacion where CSV = @CSV
END
