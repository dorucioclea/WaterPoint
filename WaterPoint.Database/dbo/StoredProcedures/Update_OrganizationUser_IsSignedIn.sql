CREATE PROCEDURE [dbo].[Update_OrganizationUser_IsSignedIn]
	@credentialid INT,
	@organizationid INT,
	@organizationuserid INT,
	@issignedin BIT
AS
SET NOCOUNT ON;
BEGIN

	UPDATE dbo.OrganizationUser
	SET IsSignedIn = 0
	WHERE
		OrganizationId = @organizationid
		AND CredentialId = @credentialid

	UPDATE dbo.OrganizationUser
	SET IsSignedIn = @issignedin
	WHERE
		OrganizationId = @organizationid
		AND CredentialId = @credentialid		
		AND Id = @organizationuserid

	SELECT @@ROWCOUNT
END
GO
