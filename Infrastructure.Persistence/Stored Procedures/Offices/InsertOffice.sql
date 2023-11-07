ALTER PROCEDURE [dbo].[InsertOffice]
(
	@City nvarchar(2048),
	@Street nvarchar(2048),
	@HouseNumber int,
	@OfficeNumber int,
	@RegistryPhoneNumber nvarchar(2048),
	@IsActive bit,
	@PhotoId uniqueidentifier
)
AS
	SET NOCOUNT OFF;
	DECLARE @Id uniqueidentifier;
	SET @Id = NEWID();
	INSERT INTO [Offices] ([Id], [City], [Street], [HouseNumber], [OfficeNumber], [RegistryPhoneNumber], [IsActive], [PhotoId])
	VALUES (@Id, @City, @Street, @HouseNumber, @OfficeNumber, @RegistryPhoneNumber, @IsActive, @PhotoId);
	
	SELECT * FROM Offices WHERE (Id = @Id)