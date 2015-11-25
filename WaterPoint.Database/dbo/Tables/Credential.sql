CREATE TABLE [dbo].[Credential]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [CredentialTypeId] INT NOT NULL,
    [Email] VARCHAR(200) NOT NULL,
    [Password] VARCHAR(50) NULL,
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	CONSTRAINT [FK_Credential_CredentialType] FOREIGN KEY ([CredentialTypeId]) REFERENCES [dbo].[CredentialType]([Id]),
)
