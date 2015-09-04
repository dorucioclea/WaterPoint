CREATE TABLE [dbo].[Variant]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [ShopId] INT NOT NULL,
    [VariantTypeId] INT NOT NULL,
	[Value] VARCHAR(10) NOT NULL,
    [DisplayName] VARCHAR(30) NULL,
    [Order] INT NULL,
    CONSTRAINT [FK_Variant_VariantType] FOREIGN KEY (VariantTypeId) REFERENCES [dbo].[VariantType] (Id),
    CONSTRAINT [FK_Variant_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([Id]), 
)
