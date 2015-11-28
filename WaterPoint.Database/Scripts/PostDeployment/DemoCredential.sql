IF NOT EXISTS(SELECT TOP 1 * FROM dbo.[Credential]) BEGIN

	DECLARE @orgId INT = (SELECT Id FROM dbo.Organization WHERE Name = 'Water Point')
	INSERT INTO dbo.[Credential]
	(OrganizationId, CredentialTypeId, Email, Password)
	VALUES
	(@orgId, (SELECT TOP 1 Id FROM dbo.CredentialType), 'hmiaosys@gmail.com', 'password')

END
GO
