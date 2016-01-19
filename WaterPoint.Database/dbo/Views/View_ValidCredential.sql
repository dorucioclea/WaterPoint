CREATE VIEW [dbo].[View_ValidCredential]
(
    [Id],
	[OrganizationUserId],
    [OrganizationId],
	[IsSignedIn],
    [OrganizationUserTypeId],
    [Email],
    [Password],
    [EntityId],
	[IsDeleted],
    [Version],
	[UtcCreated],
	[UtcUpdated],
	[Uid]
)
AS
(
	SELECT
		c.[Id],
		ou.Id AS OrganizationUserId,
		ou.[OrganizationId],		
		ou.IsSignedIn,
		ou.[OrganizationUserTypeId],
		c.[Email],
		c.[Password],
        s.Id AS [EntityId],
		c.[IsDeleted],
		c.[Version],
		c.[UtcCreated],
		c.[UtcUpdated],
		c.[Uid]
	FROM
		dbo.[Credential] c
		JOIN dbo.OrganizationUser ou ON ou.CredentialId = c.Id
		JOIN dbo.Organization o ON ou.OrganizationId = o.Id
        JOIN dbo.Staff s ON ou.Id = s.OrganizationUserId
	WHERE
		o.IsActive = 1
		AND ou.IsActive = 1
		AND c.IsDeleted = 0
        AND s.IsDeleted = 0

    UNION ALL

    SELECT
		c.[Id],
		ou.Id AS OrganizationUserId,
		ou.[OrganizationId],		
		ou.IsSignedIn,
		ou.[OrganizationUserTypeId],
		c.[Email],
		c.[Password],
        cus.Id AS [EntityId],
		c.[IsDeleted],
		c.[Version],
		c.[UtcCreated],
		c.[UtcUpdated],
		c.[Uid]
	FROM
		dbo.[Credential] c
		JOIN dbo.OrganizationUser ou ON ou.CredentialId = c.Id
		JOIN dbo.Organization o ON ou.OrganizationId = o.Id
        JOIN dbo.Customer cus ON ou.Id = cus.OrganizationUserId
	WHERE
		o.IsActive = 1
		AND ou.IsActive = 1
		AND c.IsDeleted = 0
        AND cus.IsDeleted = 0
);
GO


