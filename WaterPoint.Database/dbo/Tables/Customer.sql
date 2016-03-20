CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
	[OrganizationUserId] INT NULL,
    [LastChangeOrganizationUserId] INT NULL,
    [CustomerTypeId] INT NOT NULL,
	[IsProspect] BIT NOT NULL DEFAULT(0),
	[Gender] CHAR(1) NULL,
    [Code] VARCHAR(50) NULL,
	[FirstName] NVARCHAR(200) NOT NULL,
	[LastName] NVARCHAR(200) NOT NULL,
	[OtherName] NVARCHAR(200) NULL,
    [Phone] VARCHAR(50) NULL,
    [MobilePhone] VARCHAR(50) NULL,
    [Email] VARCHAR(100) NULL,
	[Dob] DATE NULL,
	[IsDeleted] BIT NOT NULL DEFAULT(0),
	[InvoiceCustomerId] INT NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	[SearchName] AS (LastName + ' ' + FirstName + CASE WHEN OtherName IS NULL THEN '' ELSE ' ' + OtherName END),
	CONSTRAINT [PK_dbo_Customer_Id] PRIMARY KEY CLUSTERED ([Id] ASC), -- WITH (DATA_COMPRESSION = PAGE),
    CONSTRAINT [FK_dbo_Customer_CustomerType] FOREIGN KEY ([CustomerTypeId]) REFERENCES [dbo].[CustomerType]([Id]),-- ON DELETE SET NULL,
    CONSTRAINT [FK_dbo_Customer_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_dbo_Customer_dbo_OrganizationUser] FOREIGN KEY ([LastChangeOrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id]),
	CONSTRAINT [UQ_dbo_Customer_Uid] UNIQUE NONCLUSTERED ([Uid] ASC), -- WITH (DATA_COMPRESSION = PAGE)
);
GO

CREATE FULLTEXT INDEX ON [dbo].[Customer]
(
	Code LANGUAGE 1033,
	Email LANGUAGE 1033,
    SearchName LANGUAGE 2052
)
KEY INDEX [PK_dbo_Customer_Id]
ON [SiteSearch]
WITH STOPLIST OFF;
GO
