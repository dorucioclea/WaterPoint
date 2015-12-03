CREATE TABLE [dbo].[Component]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [Code] VARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
)
