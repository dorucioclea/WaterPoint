CREATE PROCEDURE [dbo].[Update_OrganizationUser_IsSignedIn]
	@organizationid INT,
	@organizationuserid INT,
	@issignedin BIT
AS
SET NOCOUNT ON;
BEGIN
	UPDATE ou
	SET ou.IsSignedIn = 0
	FROM dbo.OrganizationUser ou
		JOIN dbo.[Credential] c ON ou.CredentialId = c.Id	
	WHERE
		OrganizationId = @organizationid
		AND @organizationuserid = @organizationuserid

	UPDATE dbo.OrganizationUser
	SET IsSignedIn = @issignedin
	WHERE
		OrganizationId = @organizationid		
		AND Id = @organizationuserid

	SELECT @@ROWCOUNT
END
GO
