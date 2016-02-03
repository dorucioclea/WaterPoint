CREATE TABLE [dbo].[Staff]
(
    [Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
    [OrganizationUserId] INT NOT NULL,
    [BaseRate] DECIMAL(10,3) NOT NULL,
    [BillableRate] DECIMAL(10,3) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[OtherName] NVARCHAR(50) NULL,
    [MobilePhone] VARCHAR(50) NULL,
	[Dob] DATE NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [IsWorking] BIT NOT NULL DEFAULT(1),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID())
    CONSTRAINT [PK_dbo_Staff_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_Staff_dbo_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_dbo_Staff_dbo_OrganizationUser] FOREIGN KEY ([OrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id])
)
