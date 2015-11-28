IF (NOT EXISTS (SELECT TOP 1 * FROM dbo.[Credential])) BEGIN
    DECLARE @orgId INT = (SELECT Id FROM dbo.Organization WHERE Name = 'Water Point')
	DECLARE @credentialId INT = (SELECT Id FROM dbo.[Credential] WHERE Email = 'hmiaosys@gmail.com')

	INSERT INTO [dbo].[Staff]
           ([OrganizationId],[CredentialId],[Email],[BaseRate],[BillableRate],[FirstName],[LastName])
           
     VALUES
           (@orgId,@credentialId,'hmiaosys@gmail.com',10,20,N'淼',N'黄')
END
GO

