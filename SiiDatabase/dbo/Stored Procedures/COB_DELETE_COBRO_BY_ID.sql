﻿CREATE PROCEDURE [dbo].[COB_DELETE_COBRO_BY_ID]
	@Id int
AS
BEGIN
	DELETE Cobros WHERE Id = @Id
END
