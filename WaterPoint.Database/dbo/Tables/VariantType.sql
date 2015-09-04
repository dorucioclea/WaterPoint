CREATE TABLE [dbo].[VariantType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,     
    [ShopId] INT NOT NULL,
    [Name] VARCHAR(10) NOT NULL,
    CONSTRAINT [FK_VariantType_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([Id]),
)
