CREATE TABLE [dbo].[Staff]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [CredentialId] INT NOT NULL,
    [Email] VARCHAR(150) NULL,
    [BaseRate] DECIMAL(10,3) NOT NULL,
    [BillableRate] DECIMAL(10,3) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[OtherName] NVARCHAR(50) NULL,
    [MobilePhone] VARCHAR(50) NULL,
	[Dob] DATE NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [IsActive] BIT NOT NULL DEFAULT(1),
    [Note] NVARCHAR(500) NULL,
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),

    CONSTRAINT [FK_Staff_Credential] FOREIGN KEY ([CredentialId]) REFERENCES [dbo].[Credential]([Id])
)
