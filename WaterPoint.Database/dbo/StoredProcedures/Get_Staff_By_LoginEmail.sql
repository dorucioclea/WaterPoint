CREATE PROCEDURE [dbo].[Get_Staff_By_LoginEmail]
    @organizationId INT,
    @loginemail VARCHAR(200)
AS
SET NOCOUNT ON;
BEGIN
    SELECT
        s.[Id]
        ,s.[OrganizationId]
        ,s.[OrganizationUserId]
        ,s.[BaseRate]
        ,s.[BillableRate]
        ,s.[FirstName]
        ,s.[LastName]
        ,s.[OtherName]
        ,s.[MobilePhone]
        ,s.[Dob]
        ,s.[IsDeleted]
        ,s.[Version]
        ,s.[UtcCreated]
        ,s.[UtcUpdated]
        ,s.[Uid]
    FROM [dbo].[Staff] s
        JOIN [dbo].[OrganizationUser] ou ON s.OrganizationUserId = ou.Id
		JOIN [dbo].[Credential] c ON ou.CredentialId = c.Id
    WHERE
        s.OrganizationId = @organizationId
        AND c.Email = @loginemail
        AND ou.OrganizationUserTypeId IN (1, 2)
END
GO
