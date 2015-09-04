CREATE TABLE [dbo].[Credential]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [StaffId] INT NULL,
    [CustomerId] INT NULL,
    [Email] VARCHAR(200) NOT NULL,
    [Password] VARCHAR(50) NULL,
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	[UtcCreatedOn] DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdatedOn] DATETIME2(7) NOT NULL DEFAULT(GETUTCDATE()),
    CONSTRAINT [FK_Credential_Staff] FOREIGN KEY ([StaffId]) REFERENCES [dbo].[Staff]([Id]),
    CONSTRAINT [FK_Credential_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]),
)
