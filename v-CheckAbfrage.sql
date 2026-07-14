USE [Heijunka]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[HJ_GetOperationInfo]
		@Workorder = N'31122949'

SELECT	@return_value as 'Return Value'

GO
