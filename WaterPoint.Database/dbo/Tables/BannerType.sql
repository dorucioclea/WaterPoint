CREATE TABLE [dbo].[BannerType]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [ShopId] INT NOT NULL,
    [Name] VARCHAR(100) NULL,    
    CONSTRAINT [FK_BrandType_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([Id]),
)
