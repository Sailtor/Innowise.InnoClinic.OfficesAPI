ALTER PROCEDURE [dbo].[UpdateOffice]
(
	@City nvarchar(2048),
	@Street nvarchar(2048),
	@HouseNumber int,
	@OfficeNumber int,
	@RegistryPhoneNumber nvarchar(2048),
	@IsActive bit,
	@PhotoId uniqueidentifier,
	@Original_Id uniqueidentifier
)
AS
	SET NOCOUNT OFF;
	UPDATE [Offices] 
	SET [City] = @City,
		[Street] = @Street,
		[HouseNumber] = @HouseNumber,
		[OfficeNumber] = @OfficeNumber,
		[RegistryPhoneNumber] = @RegistryPhoneNumber,
		[IsActive] = @IsActive,
		[PhotoId] = @PhotoId
	WHERE [Id] = @Original_Id;