CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,    
    [OrganizationId] INT NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(200) NULL,
    [LongDescription] VARCHAR(MAX) NULL,
    [IsActive] BIT NOT NULL DEFAULT(0),    
    [UtcCreated] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(), 
    [UtcUpdated] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_Category_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
)
