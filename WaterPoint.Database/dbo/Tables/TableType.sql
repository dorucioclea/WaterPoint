CREATE TABLE [dbo].[TableType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[BranchId] INT NOT NULL, 
	[Name] NVARCHAR(100) NOT NULL,
    CONSTRAINT [FK_TableType_Branch] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch] ([Id])
)
