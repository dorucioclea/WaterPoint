CREATE VIEW [dbo].[View_ValidCredential]
(
    [Id],
    [OrganizationId],
    [CredentialTypeId],
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
		c.[OrganizationId],
		c.[CredentialTypeId],
		c.[Email],
		c.[Password],
		c.[IsDeleted],
		c.[Version],
		c.[UtcCreated],
		c.[UtcUpdated],
		c.[Uid]
	FROM
		dbo.[Credential] c
		JOIN dbo.Organization o ON c.OrganizationId = o.Id

	WHERE o.IsActive = 1 AND c.IsDeleted = 0
);
GO


