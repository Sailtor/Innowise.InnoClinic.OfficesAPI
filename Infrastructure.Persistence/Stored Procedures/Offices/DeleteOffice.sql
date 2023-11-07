ALTER PROCEDURE [dbo].[DeleteOffice]
(
	@Original_Id uniqueidentifier
)
AS
	SET NOCOUNT OFF;
	DELETE FROM [Offices] WHERE [Id] = @Original_Id