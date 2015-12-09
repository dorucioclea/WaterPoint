CREATE TABLE [dbo].[Credential]
(
    [Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
    [CredentialTypeId] INT NOT NULL,
    [Email] VARCHAR(200) NOT NULL,
    [Password] VARCHAR(50) NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_Credential_Id] PRIMARY KEY CLUSTERED (Id ASC),
	CONSTRAINT [FK_Credential_CredentialType] FOREIGN KEY ([CredentialTypeId]) REFERENCES [dbo].[CredentialType]([Id]),
)
