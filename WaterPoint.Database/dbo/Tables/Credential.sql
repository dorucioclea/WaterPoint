CREATE TABLE [dbo].[Credential]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL, 
    [Email] VARCHAR(100) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [CreatedOn] DATETIME2(0) NOT NULL, 
    [UpdatedOn] DATETIME2(0) NOT NULL
)
