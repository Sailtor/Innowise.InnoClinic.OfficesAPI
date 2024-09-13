CREATE PROCEDURE [dbo].[SelectOffice]
(
	@Id uniqueidentifier
)
AS
	SET NOCOUNT ON;
SELECT *
FROM Offices
WHERE Offices.Id = @Id;