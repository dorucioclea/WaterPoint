CREATE PROCEDURE [dbo].[Undelete_Staff_By_LoginEmail]
	@organizationid INT,
    @loginemail VARCHAR(200)
AS
SET NOCOUNT ON;
BEGIN
	UPDATE s
    SET s.IsDeleted = 0
    FROM dbo.[Credential] c
        JOIN dbo.OrganizationUser ou ON ou.CredentialId = c.Id
        JOIN dbo.Staff s ON s.OrganizationUserId = ou.Id
    WHERE
        s.OrganizationId = @organizationid
        AND c.Email = @loginemail

    UPDATE ou
    SET ou.IsDeleted = 0
    FROM dbo.[Credential] c
        JOIN dbo.OrganizationUser ou ON ou.CredentialId = c.Id
        JOIN dbo.Staff s ON s.OrganizationUserId = ou.Id
    WHERE
        s.OrganizationId = @organizationid
        AND c.Email = @loginemail

    UPDATE c
    SET c.IsDeleted = 0
    FROM dbo.[Credential] c
        JOIN dbo.OrganizationUser ou ON ou.CredentialId = c.Id
        JOIN dbo.Staff s ON s.OrganizationUserId = ou.Id
    WHERE
        s.OrganizationId = @organizationid
        AND c.Email = @loginemail

	SELECT @@ROWCOUNT
END
GO
