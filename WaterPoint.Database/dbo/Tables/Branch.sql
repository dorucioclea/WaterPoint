CREATE TABLE [dbo].[Branch]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NULL,
    [IsActive] BIT NOT NULL DEFAULT(0),
    [IsMainBranch] BIT NOT NULL DEFAULT(0),
    [ShopId] INT NOT NULL,
    CONSTRAINT [FK_Branch_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([Id]),
)
