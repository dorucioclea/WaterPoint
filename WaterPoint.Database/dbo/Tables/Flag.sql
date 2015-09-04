CREATE TABLE [dbo].[Flag]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [ShopId] INT NOT NULL,
    [Name] VARCHAR(15) NOT NULL,
    CONSTRAINT [FK_Flag_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([Id]),
)
