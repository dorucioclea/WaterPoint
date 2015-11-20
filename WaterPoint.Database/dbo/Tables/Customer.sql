CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [CustomerTypeId] INT NULL,
    [Code] VARCHAR(50) NULL,
	[FirstName] NVARCHAR(200) NOT NULL,
	[LastName] NVARCHAR(200) NOT NULL,
	[OtherName] NVARCHAR(200) NULL,
    [Phone] VARCHAR(50) NULL,
    [MobilePhone] VARCHAR(50) NULL,
    [Email] VARCHAR(100) NULL,
	[Dob] DATE NULL,
    [UpdatedByStaffId] INT NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_Customer_CustomerType] FOREIGN KEY ([CustomerTypeId]) REFERENCES [dbo].[CustomerType]([Id]),
    CONSTRAINT [FK_Customer_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_Customer_Staff] FOREIGN KEY ([UpdatedByStaffId]) REFERENCES [dbo].[Staff]([Id])
)
