CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL, 
    [CreatedOn] DATETIME2(0) NOT NULL DEFAULT getutcdate(), 
    [UpdatedOn] DATETIME2(0) NOT NULL DEFAULT getutcdate() 
)
