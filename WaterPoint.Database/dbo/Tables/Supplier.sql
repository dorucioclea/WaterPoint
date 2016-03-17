CREATE TABLE [dbo].[Supplier]
(
    [Id] INT NOT NULL IDENTITY,
	[OrganizationId] INT NOT NULL,
    [LastChangeOrganizationUserId] INT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[Phone] VARCHAR(50) NULL,
    [MobilePhone] VARCHAR(50) NULL,
	[Email] VARCHAR(100) NULL,
	[WebSite] VARCHAR(100) NULL,
    [Version] ROWVERSION NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT(1),
	[IsDeleted] BIT NOT NULL DEFAULT(0),
    [UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_Supplier_Id] PRIMARY KEY CLUSTERED (Id ASC),
	CONSTRAINT [FK_dbo_Supplier_dbo_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_dbo_Supplier_dbo_OrganizationUser] FOREIGN KEY ([LastChangeOrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id])
)
