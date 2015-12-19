CREATE VIEW [dbo].[View_ValidCredential]
(
    [Id],
	[OrganizationUserId],
    [OrganizationId],
    [OrganizationUserTypeId],
    [Email],
    [Password],
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
		ou.[OrganizationUserTypeId],
		c.[Email],
		c.[Password],
		c.[IsDeleted],
		c.[Version],
		c.[UtcCreated],
		c.[UtcUpdated],
		c.[Uid]
	FROM
		dbo.[Credential] c
		JOIN dbo.OrganizationUser ou ON ou.CredentialId = c.Id
		JOIN dbo.Organization o ON ou.OrganizationId = o.Id

	WHERE
		o.IsActive = 1
		AND ou.IsActive = 1
		AND c.IsDeleted = 0
);
GO


