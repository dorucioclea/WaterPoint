CREATE TABLE [dbo].[OrganizationUser]
(
    [Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
    [CredentialId] INT NOT NULL,
	[OrganizationUserTypeId] INT NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [IsActive] BIT NOT NULL DEFAULT(1),
    [Note] NVARCHAR(500) NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_OrganizationUser_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_OrganizationUser_dbo_Credential] FOREIGN KEY ([CredentialId]) REFERENCES [dbo].[Credential]([Id])
)
