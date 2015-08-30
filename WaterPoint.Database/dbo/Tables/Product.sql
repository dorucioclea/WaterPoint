CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(150) NOT NULL,
    [Description] VARCHAR(MAX) NULL, 
    [CreatedOn] DATETIME2(0) NOT NULL DEFAULT getutcdate(), 
    [UpdatedOn] DATETIME2(0) NOT NULL DEFAULT getutcdate()
)
