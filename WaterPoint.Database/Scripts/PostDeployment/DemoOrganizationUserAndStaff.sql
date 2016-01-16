IF (NOT EXISTS (SELECT TOP 1 * FROM dbo.[OrganizationUser])) BEGIN
    DECLARE @orgId INT = (SELECT Id FROM dbo.Organization WHERE Name = 'Water Point')
	DECLARE @credentialId INT = (SELECT Id FROM dbo.[Credential] WHERE Email = 'hmiaosys@gmail.com')

	INSERT INTO [dbo].[OrganizationUser]
        ([OrganizationId],[CredentialId],[OrganizationUserTypeId])
    VALUES
        (@orgId,@credentialId,1)

    DECLARE @orgUserId INT = (SELECT SCOPE_IDENTITY())

    INSERT INTO [dbo].[Staff]
        ([OrganizationId], [OrganizationUserId], [BaseRate], [BillableRate], [FirstName], [LastName])
    VALUES
        (@orgId, @orgUserId, 80, 100, N'淼', N'黄')
END
GO
