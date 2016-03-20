CREATE TABLE [dbo].[Contact]
(
    [Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
    [LastChangeOrganizationUserId] INT NULL,
	[FirstName] NVARCHAR(200) NOT NULL,
	[LastName] NVARCHAR(200) NOT NULL,
	[OtherName] NVARCHAR(200) NULL,
    [Phone] VARCHAR(50) NULL,
    [MobilePhone] VARCHAR(50) NULL,
    [Email] VARCHAR(100) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_Contact_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_Contact_dbo_OrganizationUser] FOREIGN KEY ([LastChangeOrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id])
)
